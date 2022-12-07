
using System;
using System.Collections.Generic;
using Utility.Tools.Auth;

namespace Core.Entities.Dto
{
    public class UserLoginDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public string Mobile { get; set; }
        public long CreatedAt { get; set; }
        public int? Age { get; set; }
        //public JsonWebToken Token { get; set; }
    }
}
