using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class GetByIdChallengeDto
    {
        public Guid Id { get; set; }
    }

    public class GetByIdChallengeResultDto : BaseApiResult
    {
        public ChallengeObject  Object  { get; set; }
    }
}
