using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class DeleteFileRequestDto
    {
        public Guid Id { get; set; }
    }

    public class DeleteFileRequestResultDto : BaseApiResult
    {

    }
}
