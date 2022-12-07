using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class ListCategoryDto
    {
        public Guid LanguageId { get; set; }
        public Guid UserId { get; set; }
    }

    public class ListCategoryMobileResultDto : BaseApiResult
    {
        public ListCategoryResultObject Object { get; set; }
    }

    public class ListCategoryResultDto : BaseApiResult
    {
        public List<Category>? Object { get; set; }
    }

    public class ListCategoryResultObject 
    {
        public List<Category>? Categories { get; set; }
        public LastSubCategoryObject? LastSubCategory { get; set; }
    }

}