using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;

using Utility.Tools.Notification;

namespace Utility.Tools.SMS.Rahyab
{
    public class TrezSMSCounter : ISMSCounter
    {
        private readonly IConfiguration configuration;

        public TrezSMSCounter(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public int Execute()
        {
            configuration.GetSection<TrezParameters>();
            return 1;
        }

        

        
    }

}
