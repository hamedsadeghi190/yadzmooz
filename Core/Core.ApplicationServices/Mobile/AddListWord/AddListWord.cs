using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using Core.Mongo.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddListWord : IAddListWord
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;
        private readonly IGenerateChallenge generateChallenge;

        public AddListWord
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler,
            IGenerateChallenge generateChallenge)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
            this.generateChallenge = generateChallenge;
        }


        public Entities.Dto.AddListWordResultDto Execute(AddListWordDto dto)
        {

            if (dto.Intry[0].SubCategoryId == null)
            {
                var sub = new SubCategory
                {
                    Id = Guid.NewGuid(),
                    CategoryId = dto.Intry[0].CategoryId.ToGuid(),
                    Challenges = null,
                    CreatedAt = Agent.Now,
                    Description = null,
                    Icon = null,
                    Title = dto.Intry[0].SubCategoryTitle
                };

                dto.Intry[0].SubCategoryId = sub.Id;

                foreach (var item in dto.Intry)
                {
                    item.SubCategoryId = sub.Id;
                }


                unit.SubCategories.Insert(sub);
            }
            else
            {
               var categoryId = unit.SubCategories.GetCategoryBySubCategory(dto.Intry[0].SubCategoryId.ToGuid());
                foreach (var item in dto.Intry)
                {
                    item.CategoryId = categoryId;
                }
            }

            foreach (var item in dto.Intry)
            {



                if (!unit.Words.CheckExist(item.Word))
                {

                    if (item.CategoryId != null || item.SubCategoryId != null)
                    {
                        var languageId = unit.Categories.GetLanguageByCategory(item.CategoryId);

                        var language = unit.Languages.GetLanguageById(languageId);


                        var Word = new Words
                        {
                            CreatedAt = Agent.Now,
                            CategoryId = item.CategoryId,
                            ImageFile = item.ImageFile,
                            Meaning = item.Meaning,
                            LanguageId = language.Id,
                            LanguageUtc = language.LanguageUtc,
                            SubCategoryId = item.SubCategoryId.ToGuid(),
                            Id = new Guid(),
                            Word = item.Word,
                            VoiceFile = item.VoiceFile,
                            Status = 1
                        };


                        unit.Words.Insert(Word);
                        //create challenges 
                        generateChallenge.Execute(Word);
                    }

                    
                }











            }







            return new AddListWordResultDto
            {
                Code = 0,
                IsSuccess = true,
                Message = Messages.OK
            };
        }
    }
}
