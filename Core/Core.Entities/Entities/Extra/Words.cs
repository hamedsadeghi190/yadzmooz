using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class Words : BaseEntity
    {
        public Guid? CategoryId { get; set; }
        public Guid SubCategoryId { get; set; }
        public Guid LanguageId { get; set; }
        public string  Meaning{ get; set; }
        public string  Word{ get; set; }
        public string  VoiceFile{ get; set; }
        public string  ImageFile{ get; set; }
        public int Status{ get; set; }
        public int LanguageUtc{ get; set; }
    }

  


}


