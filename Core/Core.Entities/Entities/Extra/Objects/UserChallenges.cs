using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class UserChallenge 
    {
        public string? Title { get; set; }
        public string Meanings { get; set; }
        public string Word { get; set; }
        public ShortCategory Category{ get; set; }
        public ShortLanguage Language{ get; set; }
        public ShortSubCategory SubCategory{ get; set; }

    }

 
}


