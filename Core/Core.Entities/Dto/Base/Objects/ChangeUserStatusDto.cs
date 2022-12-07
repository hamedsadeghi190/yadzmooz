using Enums;
using System;

namespace Core.Entities.Mongo.Dto
{
    public class ChangeUserStatusDto
    {
        public Guid UserId { get; set; }
        public Enums.UserStatus UserStatus { get; set; }

    }
    public class ChangeUserStatusResultDto : BaseApiResult
    {

    }
}
