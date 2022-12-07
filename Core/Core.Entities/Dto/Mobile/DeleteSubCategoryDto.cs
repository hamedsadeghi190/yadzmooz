using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class DeleteSubCategoryDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class DeleteSubCategoryResultDto : BaseApiResult
    {

    }
}
