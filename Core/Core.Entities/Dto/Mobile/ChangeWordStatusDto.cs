using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class ChangeWordStatusDto
    {
        public Guid Id{ get; set; }
        public int Status{ get; set; }


    }

    public class ChangeWordStatusResultDto : BaseApiResult
    {

    }
}
