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
    public class ListChallenge : IListChallenge
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public ListChallenge
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public ListChallengeResultDto Execute(ListChallengeDto dto)
        {


            return new ListChallengeResultDto
            {
                Code = 0,
                IsSuccess = true,
                Message = Messages.Success,
                Object = unit.Challenges.GetBySubCategory(dto.SubCategoryId)
            };

        }
    }
}
