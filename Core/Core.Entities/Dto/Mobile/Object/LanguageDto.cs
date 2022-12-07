using System;
using System.Collections.Generic;

namespace Core.Entities.Mongo.Dto
{
    public class LanguageDto
    {
        public Guid Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public int? LanguageType { get; set; }

    }


}
