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
    public class AddListChallenge : IAddListChallenge
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public AddListChallenge
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public Entities.Dto.AddListChallengeResultDto Execute(AddListChallengeDto dto)
        {

   

            foreach (var item in dto.Intry)
            {

                

                var challenge = new Challenge
                {
                    CreatedAt = Agent.Now,
                    CorrectAnswer = item.CorrectAnswer,
                    Meanings = item.Meanings,
                    Id = new Guid(),
                    Options = item.Options,
                    Type = item.Type,
                    SubCategoryId = item.SubCategoryId,
                    Word = item.Word,
                    Title = item.Title,
                };


                unit.Challenges.Insert(challenge);
                unit.SubCategories.AddChallengeToSubCategory(challenge.Id, challenge.SubCategoryId);
            }







            return new AddListChallengeResultDto 
            {
                Code = 0 ,
                IsSuccess = true,
                Message = Messages.OK
            };
        }
    }
}
