using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entities.Mongo
{
    public class Slider : BaseEntity
    {                
        public string Destination { get; set; }
        public string Link{ get; set; }        
        public File Document{ get; set; }
    }
}