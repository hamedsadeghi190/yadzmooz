using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class GetByIdFileRequestDto
    {
        public Guid Id { get; set; }
    }

    public class GetByIdFileRequestResultDto : BaseApiResult
    {
        public FileRequest Object{ get; set; }
    }
}
