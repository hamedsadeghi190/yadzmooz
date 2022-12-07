using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class GetByIdSubCategoryDto
    {
        public Guid Id { get; set; }
    }

    public class GetByIdSubCategoryResultDto : BaseApiResult
    {
        public SubCategory  Object  { get; set; }
    }
}
