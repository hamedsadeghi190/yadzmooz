using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;

using Utility.Tools.Notification;

namespace Utility.Tools.SMS.Rahyab
{
    public class RahyabSMSCounter : ISMSCounter
    {
        private readonly IConfiguration configuration;

        public RahyabSMSCounter(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public int Execute()
        {
            configuration.GetSection<RahyabParameters>();
            Cls_SMS.ClsGetRemain remain = new Cls_SMS.ClsGetRemain();
            return remain.MyASC(RahyabParameters.Username);
        }

        

        
    }

}
