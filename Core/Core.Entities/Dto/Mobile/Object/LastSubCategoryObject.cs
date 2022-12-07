using System;
using System.Collections.Generic;

namespace Core.Entities.Mongo.Dto
{
    public class LastSubCategoryObject
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public int? ChallengeCount { get; set; }
        public int? ChallengePassed { get; set; }
        public string? CategoryTitle { get; set; }

    }


}
