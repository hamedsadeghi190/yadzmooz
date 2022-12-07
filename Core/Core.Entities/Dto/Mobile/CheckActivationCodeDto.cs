using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class CheckActivationCodeDto
    {
        public string Mobile { get; set; }
        public string Code { get; set; }
        public string PushId{ get; set; }
    }

    public class CheckActivationCodeResultDto : BaseApiResult
    {
        public UserLoginDto Object { get; set; }
    }
}
