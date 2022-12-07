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
    public class AddSubCategory : IAddSubCategory
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public AddSubCategory
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public Entities.Dto.AddSubCategoryResultDto Execute(AddSubCategoryDto dto)
        {

            var category = new SubCategory
            {
                CreatedAt = Agent.Now,
                Description = dto.Description,
                Icon = dto.Icon,
                Id = new Guid(),
                CategoryId = dto.CategoryId,
                Title = dto.Title
            };


            unit.SubCategories.Insert(category);
            unit.Categories.AddSubCategoryToCategory(dto,category.Id);


            return new AddSubCategoryResultDto 
            {
                Code = 0 ,
                IsSuccess = true,
                Message = Messages.OK,

            };
        }
    }
}
