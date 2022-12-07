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
    public class DeleteSubCategory : IDeleteSubCategory
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public DeleteSubCategory
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public DeleteSubCategoryResultDto Execute(DeleteSubCategoryDto dto)
        {


            unit.SubCategories.Delete(dto.Id);
            unit.Categories.DeleteSubCategory(dto.Id, dto.CategoryId);

            return new DeleteSubCategoryResultDto 
            {
                Code = 0 ,
                IsSuccess = true,
                Message = Messages.OK
            };
        }
    }
}
