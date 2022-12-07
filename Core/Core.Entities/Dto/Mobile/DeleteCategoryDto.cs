using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class DeleteCategoryDto
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
    }

    public class DeleteCategoryResultDto : BaseApiResult
    {

    }
}
