using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class Update : BaseEntity
    {
        public string Version { get; set; }
        public string Description { get; set; }
        public bool Restricted { get; set; }
        public string Link { get; set; }

    }
}


