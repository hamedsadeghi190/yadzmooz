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
    public class DeleteCategory : IDeleteCategory
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public DeleteCategory
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public DeleteCategoryResultDto Execute(DeleteCategoryDto dto)
        {


            unit.Categories.Delete(dto.Id);
            unit.Languages.DeleteCategory(dto.Id, dto.LanguageId);

            return new DeleteCategoryResultDto 
            {
                Code = 0 ,
                IsSuccess = true,
                Message = Messages.OK
            };
        }
    }
}
