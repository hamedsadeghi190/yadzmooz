using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class FileRequest : BaseEntity
    {
        public string Title{ get; set; }
        public string Location { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }

    }

 
}


