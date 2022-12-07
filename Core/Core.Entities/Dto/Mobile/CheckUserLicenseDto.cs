using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class CheckUserLicenseDto
    {
        public Guid UserId{ get; set; }

    }

    public class CheckUserLicenseResultDto : BaseApiResult
    {
        public CheckUserLicenseObject Object { get; set; }
    }
    public class CheckUserLicenseObject
    {
        public bool IsValid{ get; set; }

    }
}
