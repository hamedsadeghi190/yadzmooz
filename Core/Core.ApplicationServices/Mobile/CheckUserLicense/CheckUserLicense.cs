using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using Core.Entities.Mongo.Enums;
using Core.Mongo.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class CheckUserLicense : ICheckUserLicense
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public CheckUserLicense
            (
            IUnitOfWork unit,
             IJwtHandler jwtHandler
            )
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public CheckUserLicenseResultDto Execute(CheckUserLicenseDto dto)
        {

            var user = unit.Users.GetById(dto.UserId);


            if (user.SubscriptionExpireDate > Agent.Now)
            {
                return new CheckUserLicenseResultDto
                {
                    Code = 0,
                    IsSuccess = true,
                    Message = "لایسنس کاربر فعال است",
                    Object = new CheckUserLicenseObject { IsValid = true }
                };
            }
            else
            {
                return new CheckUserLicenseResultDto
                {
                    Code = 0,
                    IsSuccess = false,
                    Message = "لایسنس کاربر فعال نیست",
                    Object = new CheckUserLicenseObject { IsValid = false }
                };
            }

            

          
            

        }
    }
}
