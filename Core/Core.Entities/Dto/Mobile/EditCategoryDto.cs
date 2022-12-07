using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class EditCategoryDto
    {
        public Guid Id{ get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

    }

    public class EditCategoryResultDto : BaseApiResult
    {

    }
}
