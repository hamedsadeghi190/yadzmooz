using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Utility.Tools.General;
using Utility.Tools.Notification;

namespace Core.ApplicationServices
{
    public class EditProfile : IEditProfile
    {
        private readonly IUnitOfWork unit;
        private readonly INotification notification;
        private readonly IConfiguration configuration;

        public EditProfile
            (
            IUnitOfWork unit
            , INotification notification,
            IConfiguration configuration
            )
        {
            this.unit = unit;
            this.notification = notification;
            this.configuration = configuration;
        }


        public EditProfileResultDto Execute(EditProfileDto dto)
        {

            var result = new EditProfileResultDto()
            {
                Code = 0,
                IsSuccess = false,
                Message = Messages.UserNotExist,
                
            };

            var user = unit.Users.GetUserById(dto.UserId);

            if (user != null)
            {

                if (!(unit.Users.UserNameExist(dto.UserName)))
                {
                    user.Email = dto.Email;
                    user.UserName = dto.UserName;
                    user.Image = dto.Image;
                    user.Age = dto.Age;

                    unit.Users.Update(user);

                    result.Code = StatusCodes.Successful;
                    result.IsSuccess = true;
                    result.Message = Messages.OK;
                }
                else
                {
                    result.Code = 101;
                    result.IsSuccess= false;
                    result.Message= Messages.UserNameTakan;
                }                

            }
            
            return result;

        }
    }
}
