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
    public class GetByIdChallenge : IGetByIdChallenge
    {
        private readonly IUnitOfWork unit;

        public GetByIdChallenge
            (
            IUnitOfWork unit
            )
        {
            this.unit = unit;
        }


        public GetByIdChallengeResultDto Execute(GetByIdChallengeDto dto)
        {

            var challenge = unit.Challenges.GetById(dto.Id);
            var subCategory = unit.SubCategories.GetById(challenge.SubCategoryId);
            var category = unit.Categories.GetById(subCategory.CategoryId);



            return new GetByIdChallengeResultDto
            {
                Code = 0,
                IsSuccess = true,
                Message = Messages.OK,
                Object = DtoBuilder.CreateChallengeObject(challenge, category.Id, category.LanguageId)
            };
        }
    }
}
