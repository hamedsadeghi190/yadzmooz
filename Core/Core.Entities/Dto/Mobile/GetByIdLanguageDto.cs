using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class GetByIdLanguageDto
    {
        public Guid Id { get; set; }
    }

    public class GetByIdLanguageResultDto : BaseApiResult
    {
        public Language Object{ get; set; }
    }
}
