using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class Challenge : BaseEntity
    {
        public string? Title { get; set; }
        public int Type { get; set; }
        public string Meanings { get; set; }
        public string Word { get; set; }
        public List<ChallengeOptions> Options { get; set; }
        public ChallengeOptions CorrectAnswer { get; set; }
        public Guid SubCategoryId{ get; set; }
    }

    public class ShortChallenge
    {
        public Guid Id { get; set; }

    }

    public class ChallengeOptions
    {

        public Guid Id { get; set; }
        public string Word { get; set; }
#nullable enable    
        public string? Image { get; set; }
        public string? Voice { get; set; }
        public string? PairId{ get; set; }
        public bool? IsCorrecr{ get; set; }
        public int? Index{ get; set; }

    }
}


