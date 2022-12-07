using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class ActivationCode : BaseEntity
    {
        public string Code { get; set; }
        public string Mobile { get; set; }
    }
    
}


