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
    public class GetSubCategoryByArrange : IGetSubCategoryByArrange
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public GetSubCategoryByArrange
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public GetSubCategoryByArrangeResultDto Execute(GetSubCategoryByArrangeDto dto)
        {


            var subcat = unit.SubCategories.GetByCategoryByArrange(dto.CategoryId);



            return new GetSubCategoryByArrangeResultDto
            {
                Code = 0,
                IsSuccess = true,
                Message = Messages.Success,
                Object = subcat
            };

        }
    }
}
