using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class AddLanguageDto
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public int? LanguageType { get; set; }
    }

    public class AddLanguageResultDto : BaseApiResult
    {

    }
}
