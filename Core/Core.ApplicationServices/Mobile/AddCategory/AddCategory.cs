using Core.Entities.Dto;
using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using System;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddCategory : IAddCategory
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public AddCategory(IUnitOfWork unit, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public Entities.Dto.AddCategoryResultDto Execute(AddCategoryDto dto)
        {
            var category = new Category
            {
                CreatedAt = Agent.Now,
                Description = dto.Description,
                Icon = dto.Icon,
                Id = new Guid(),
                LanguageId = dto.LanguageId,
                Title = dto.Title
            };


            unit.Categories.Insert(category);
            unit.Languages.AddCategoryToLanguage(dto, category.Id);

            return new AddCategoryResultDto
            {
                Code = 0,
                IsSuccess = true,
                Message = Messages.OK
            };
        }
    }
}
