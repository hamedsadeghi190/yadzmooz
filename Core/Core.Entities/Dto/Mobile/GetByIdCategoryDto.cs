using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class GetByIdCategoryDto
    {
        public Guid Id { get; set; }
    }

    public class GetByIdCategoryResultDto : BaseApiResult
    {
        public Category  Object  { get; set; }
    }
}
