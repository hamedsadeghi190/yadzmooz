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
    public class EditCategory : IEditCategory
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public EditCategory
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public EditCategoryResultDto Execute(EditCategoryDto dto)
        {

            var cat = unit.Categories.GetById(dto.Id);
            cat.Icon = dto.Icon;
            cat.Title = dto.Title;
            cat.Description = dto.Description;

            unit.Categories.Replace(cat);


            unit.Languages.EditCategoryInLanguages(cat);
                



            return new EditCategoryResultDto 
            {
                Code  = 0,
                IsSuccess = true,
                Message = Messages.OK
                 
            };
        }
    }
}
