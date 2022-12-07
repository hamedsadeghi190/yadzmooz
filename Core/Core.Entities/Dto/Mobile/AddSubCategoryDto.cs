using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class AddSubCategoryDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public Guid CategoryId { get; set; }
    }

    public class AddSubCategoryResultDto : BaseApiResult
    {

    }
}
