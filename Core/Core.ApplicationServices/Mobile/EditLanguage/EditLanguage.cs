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
    public class EditLanguage : IEditLanguage
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public EditLanguage
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public EditLanguageResultDto Execute(EditLanguageDto dto)
        {


            var lang = unit.Languages.GetLanguageById(dto.Id);

            lang.Icon = dto.Icon;
            lang.Title = dto.Title;
            lang.LanguageType = dto.LanguageType;

            unit.Languages.Replace(lang);


            return new EditLanguageResultDto 
            {
                Code = 0 ,
                IsSuccess = true,
                Message = Messages.OK
            };

        }
    }
}
