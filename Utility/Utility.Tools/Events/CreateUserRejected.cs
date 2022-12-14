using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Tools.Events
{
    public class CreateUserRejected : IRejectedEvent
    {
        public string Reason { get; }

        public string Code { get; }
        public string Email { get; }

        protected CreateUserRejected()
        { 
        }

        public CreateUserRejected(string email,string reason,string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}
