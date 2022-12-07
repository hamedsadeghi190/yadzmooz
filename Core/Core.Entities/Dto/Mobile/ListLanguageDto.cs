using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class ListLanguageDto 
    {

    }

    public class ListLanguageResultDto : BaseApiResult
    {
        public List<LanguageDto> Object { get; set; }
    }
}
