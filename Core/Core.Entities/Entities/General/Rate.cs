using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities.Mongo
{
    public class Rate 
    {
        public string Title{ get; set; }
        public double RateValue { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }        

    }
}
