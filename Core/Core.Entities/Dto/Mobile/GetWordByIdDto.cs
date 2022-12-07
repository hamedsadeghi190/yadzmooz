using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class GetWordByIdDto
    {
        public Guid Id { get; set; }
    }
 

    public class GetWordByIdResultDto : BaseApiResult
    {
        public Words Object { get; set; }
    }

}
