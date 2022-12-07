using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{

    public class AddCheckUpdateDto
    {
        public string Version { get; set; }
        public string Description { get; set; }
        public bool Restricted { get; set; }
        public string Link { get; set; }
    }

    public class CheckUpdateDto
    {
        

    }

    public class CheckUpdateResultDto : BaseApiResult
    {
        public Update Object { get; set; }
    }

   
}
