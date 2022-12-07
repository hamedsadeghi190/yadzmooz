using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class SendActivationCodeDto
    {
        public string Mobile { get; set; }
    }

    public class SendActivationCodeResultDto : BaseApiResult
    {
    }

    public class SendActivationCodeApiDto
    {
        public string patternId { get; set; }
        public string receiver { get; set; }
        public string param { get; set; }
    }
}
