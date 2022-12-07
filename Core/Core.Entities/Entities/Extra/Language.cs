using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class Language : BaseEntity
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public int? LanguageType { get; set; }
        public int LanguageUtc { get; set; }
        public List<ShortCategory> Categories{ get; set; }
    }

    public class ShortLanguage
    {
        public Guid Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
    }

}


