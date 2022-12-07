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
    public class DeleteChallenge : IDeleteChallenge
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public DeleteChallenge
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public DeleteChallengeResultDto Execute(DeleteChallengeDto dto)
        {


            unit.Challenges.Delete(dto.Id);
            unit.SubCategories.DeleteChallenge(dto.Id, dto.SubCategoryId);

            return new DeleteChallengeResultDto 
            {
                Code = 0 ,
                IsSuccess = true,
                Message = Messages.OK
            };
        }
    }
}
