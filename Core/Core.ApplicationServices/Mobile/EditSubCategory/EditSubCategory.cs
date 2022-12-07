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
    public class EditSubCategory : IEditSubCategory
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public EditSubCategory
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public EditSubCategoryResultDto Execute(EditSubCategoryDto dto)
        {

            var cat = unit.SubCategories.GetById(dto.Id);
            cat.Icon = dto.Icon;
            cat.Title = dto.Title;
            cat.Description = dto.Description;

            unit.SubCategories.Replace(cat);
            unit.Categories.EditSubCategoryInCategory(cat);




            return new EditSubCategoryResultDto 
            {
                Code  = 0,
                IsSuccess = true,
                Message = Messages.OK
                 
            };
        }
    }
}
