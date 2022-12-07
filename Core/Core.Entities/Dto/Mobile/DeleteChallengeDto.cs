using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class DeleteChallengeDto
    {
        public Guid Id { get; set; }
        public Guid SubCategoryId { get; set; }
    }

    public class DeleteChallengeResultDto : BaseApiResult
    {

    }
}
