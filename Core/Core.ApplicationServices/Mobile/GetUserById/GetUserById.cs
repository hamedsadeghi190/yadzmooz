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
    public class GetUserById : IGetUserById
    {
        private readonly IUnitOfWork unit;
        private readonly INotification notification;
        private readonly IConfiguration configuration;

        public GetUserById
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


        public GetUserByIdResultDto Execute(GetUserByIdDto dto)
        {

            var result = new GetUserByIdResultDto()
            {
                Code = 0,
                IsSuccess = false,
                Message = Messages.UserNotExist,
                Object = null
                
            };

            var user = this.unit.Users.GetUserById(dto.Id);

            if (user != null)
            {
                result.Object = DtoBuilder.CreateUserDto(user);
                result.IsSuccess = true;
                result.Message = Messages.OK;
                result.Code = StatusCodes.Successful;
            }
            
            
            return result;

        }
    }
}
