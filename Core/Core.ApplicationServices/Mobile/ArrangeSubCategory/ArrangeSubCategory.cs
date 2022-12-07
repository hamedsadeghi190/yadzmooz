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
    public class ArrangeSubCategory : IArrangeSubCategory
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public ArrangeSubCategory
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public ArrangeSubCategoryResultDto Execute(ArrangeSubCategoryDto dto)
        {

   

            foreach (var item in dto.Intry)
            {
                var sub = unit.SubCategories.GetById(item.Id);
                sub.Piority = item.Piority;
                unit.SubCategories.Replace(sub);
            }







            return new ArrangeSubCategoryResultDto 
            {
                Code = 0 ,
                IsSuccess = true,
                Message = Messages.OK
            };
        }
    }
}
