using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class EditLanguageDto
    {
        public Guid Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public int? LanguageType { get; set; }
    }

    public class EditLanguageResultDto : BaseApiResult
    {

    }
}
