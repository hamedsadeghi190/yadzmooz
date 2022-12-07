using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Tools
{
    public interface INewFireBase
    {
        bool SendNotification(string[] devices, string title, string body, object data);        
    }


 

}
