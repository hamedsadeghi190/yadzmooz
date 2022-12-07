using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class ChallengeObject 
    {
        public string? Title { get; set; }
        public int Type { get; set; }
        public string Meanings { get; set; }
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
        public Guid CategoryId { get; set; }
        public string Word { get; set; }
        public List<ChallengeOptions> Options { get; set; }
        public ChallengeOptions CorrectAnswer { get; set; }
        public Guid SubCategoryId{ get; set; }
    }

 
}


