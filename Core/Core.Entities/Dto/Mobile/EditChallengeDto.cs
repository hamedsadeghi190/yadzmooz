using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class EditChallengeDto
    {
        public string Title { get; set; }

        public Guid Id{ get; set; }
        public int Type { get; set; }
        public string Meanings { get; set; }
        public string Word { get; set; }
        public List<ChallengeOptions> Options { get; set; }
        public ChallengeOptions CorrectAnswer { get; set; }

    }

    public class EditChallengeResultDto : BaseApiResult
    {

    }
}
