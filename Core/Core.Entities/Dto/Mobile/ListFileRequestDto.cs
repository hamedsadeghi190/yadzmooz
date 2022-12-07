using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class ListFileRequestDto
    {
        
    }

    public class ListFileRequestResultDto : BaseApiResult
    {
        public List<FileRequest> Object { get; set; }
    }
}
