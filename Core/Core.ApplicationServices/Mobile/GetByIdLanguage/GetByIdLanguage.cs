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
    public class GetByIdLanguage : IGetByIdLanguage
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public GetByIdLanguage
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public GetByIdLanguageResultDto Execute(GetByIdLanguageDto dto)
        {

            var language = unit.Languages.GetLanguageById(dto.Id);
            return new GetByIdLanguageResultDto 
            {
                Code = 0 ,
                IsSuccess = true,
                Message = Messages.OK,
                Object = language
            };

        }
    }
}
