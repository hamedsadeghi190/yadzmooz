using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using Core.Mongo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class ListLanguage : IListLanguage
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public ListLanguage
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public ListLanguageResultDto Execute(ListLanguageDto dto)
        {

            var languages = unit.Languages.GetAll();

            return new ListLanguageResultDto 
            {
                Code = 0 ,
                IsSuccess = true,
                Message = Messages.OK,
                Object = languages.Select(p=>DtoBuilder.CreateLanguageDto(p)).ToList(),
            };

        }
    }
}
