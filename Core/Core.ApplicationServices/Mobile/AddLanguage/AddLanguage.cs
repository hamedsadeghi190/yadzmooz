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
    public class AddLanguage : IAddLanguage
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public AddLanguage
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public AddLanguageResultDto Execute(AddLanguageDto dto)
        {

            unit.Languages.Insert(new Language
            {
                Categories = null,
                CreatedAt = Agent.Now,
                Icon = dto.Icon,
                Title = dto.Title,
                LanguageType = dto.LanguageType,
                Id = new Guid()
            });

            return new AddLanguageResultDto
            {
                Code = 0 ,
                IsSuccess = true,
                Message = Messages.Success
            };

        }
    }
}
