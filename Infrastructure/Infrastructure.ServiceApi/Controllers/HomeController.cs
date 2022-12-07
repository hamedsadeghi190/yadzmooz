using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Infrastructure.ServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {

        public HomeController()
        {
        }

        [HttpGet]
        public bool SMS()
        {
            //Statics.SetSMSFlag();
            //return Statics.GetSMSFlag();
            return true;
        }
        [HttpGet]
        public bool Schedule()
        {
            //Statics.SetScheduleFlag();
            //return Statics.GetScheduleFlag();
            return true;
        }
    }
}
