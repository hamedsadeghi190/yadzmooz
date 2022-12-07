using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class GetSubCategoryByArrangeDto
    {
        public Guid CategoryId{ get; set; }
    }

    public class GetSubCategoryByArrangeResultDto : BaseApiResult
    {
        public List<ArrangeSubCategoryIntryObject> Object { get; set; }

    }



}
