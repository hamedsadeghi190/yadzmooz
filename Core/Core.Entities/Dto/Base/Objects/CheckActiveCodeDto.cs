using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities.Mongo.Dto
{
    public class CheckActiveCodeDto
    {
        public string ActiveCode { get; set; }
        public string Email { get; set; }
        public string PushId { get; set; }
    }
    public class CheckActivationCodeResultDto : BaseApiResult
    {
        public UserDto Object { get; set; }
    }       
    
}
