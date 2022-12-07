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
    public class GetByIdCategory : IGetByIdCategory
    {
        private readonly IUnitOfWork unit;

        public GetByIdCategory
            (
            IUnitOfWork unit
            )
        {
            this.unit = unit;
        }


        public GetByIdCategoryResultDto Execute(GetByIdCategoryDto dto)
        {
            return new GetByIdCategoryResultDto 
            {
                Code = 0 , 
                IsSuccess = true,
                Message = Messages.OK,
                Object = unit.Categories.GetById(dto.Id)
            };
        }
    }
}
