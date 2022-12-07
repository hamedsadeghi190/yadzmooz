using System;

namespace Core.Entities.Mongo.Dto
{
    public class EditProfileDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public long? BirthDay { get; set; }
        public int? Gender { get; set; }
        public ShortFile ProfileImage { get; set; }
    }
    public class EditProfileResultDto : BaseApiResult
    {
    }
}
