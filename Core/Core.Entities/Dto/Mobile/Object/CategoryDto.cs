using System;
using System.Collections.Generic;

namespace Core.Entities.Mongo.Dto
{
    public class CategoryDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public Guid LanguageId { get; set; }

        public List<ShortSubCategory> SubCategories { get; set; }

    }


}
