using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class ListSubCategoryDto
    {
        public Guid CategoryId { get; set; }
    }

    public class ListSubCategoryResultDto : BaseApiResult
    {
        public List<SubCategory> Object{ get; set; }
    }
}
