using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class ToolTip 
    {
        public List<string> Meanings { get; set; }
        public string Pharse { get; set; }
        public ShortLanguage Language{ get; set; }
        public ShortFile Voice{ get; set; }
        public int ToolTipStatus{ get; set; }
    }

}


