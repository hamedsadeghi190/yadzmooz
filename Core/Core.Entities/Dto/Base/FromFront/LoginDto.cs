using Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class LoginDto
    {
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string DeviceId { get; set; }

    }
}
