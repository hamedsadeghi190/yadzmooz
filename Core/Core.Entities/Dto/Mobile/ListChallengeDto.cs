using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class ListChallengeDto
    {
        public Guid SubCategoryId { get; set; }
    }

    public class ListChallengeResultDto : BaseApiResult
    {
        public List<Challenge> Object{ get; set; }
    }
}
