using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class PassChallengeDto
    {
        public Guid ChallengeId { get; set; }
        public Guid UserId { get; set; }
        public Guid SubCategoryId { get; set; }
    }

    public class PassChallengeResultDto : BaseApiResult
    {

    }
}
