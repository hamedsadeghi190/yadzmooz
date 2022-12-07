using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Tools.SMS.Rahyab
{
    public class EmailParameters
    {
        public  string Host { get; set; }
        public  string Username { get; set; }
        public  string Password { get; set; }
        public  int Port { get; set; }
        public string TargetName { get;  set; }
        public string MailSender { get;  set; }
        public string Subject { get;  set; }
    }
}
