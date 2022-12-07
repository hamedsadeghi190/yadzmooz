
using System;
using System.Collections.Generic;
using Utility.Tools.Auth;

namespace Core.Entities.Mongo.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; internal set; }
        public long? Birthday { get; internal set; }
        public string Mobile { get; set; }
        public long CreatedAt { get; internal set; }
        public int? Gender { get; internal set; }
        public JsonWebToken Token { get; set; }        
        public FileDto ProfileImage{ get; internal set; }
        public string Email { get; internal set; }
        public string PrinterIp { get; set; }
        public int Status { get; internal set; }
        public int RoleId{ get; internal set; }
        //public List<RateDto> RateList { get; internal set; }
        //public double Rate { get; internal set; }
        public string Description { get; internal set; }
        //public int Likes { get; internal set; }
        //public double TimeCommitment { get; internal set; }
    }
    public class UserShortDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProfileImage { get; set; }
        public double Rate { get; internal set; }
    }
}
