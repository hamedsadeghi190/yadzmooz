using Core.Entities.Mongo.Dto;
using System;

namespace Core.Entities.Dto
{
    public class EditProfileDto
    {
        public Guid UserId { get; set; }
        public string? Image { get; set; }
        public int? Age{ get; set; }
        public string UserName{ get; set; }
        public string? Email{ get; set; }
    }


    public class EditProfileResultDto : BaseApiResult
    {
    }

}
