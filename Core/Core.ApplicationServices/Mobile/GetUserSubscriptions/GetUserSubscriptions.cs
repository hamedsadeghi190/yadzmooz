using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Utility.Tools.General;
using Utility.Tools.Notification;

namespace Core.ApplicationServices
{
    public class GetUserSubscriptions : IGetUserSubscriptions
    {
        private readonly IUnitOfWork unit;
        private readonly INotification notification;
        private readonly IConfiguration configuration;

        public GetUserSubscriptions
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


        public GetUserSubscriptionsResultDto Execute(GetUserSubscriptionsDto dto)
        {
            var result = new GetUserSubscriptionsResultDto
            {
                Code = 101,
                IsSuccess = false,
                Message=   Messages.UserNotExist,
                Object = null
            };




            var user = unit.Users.GetUserById(dto.UserId);

            if (user == null)
            {
                return result;
            }
            else
            {
                return new GetUserSubscriptionsResultDto
                {
                    Code = 0,
                    Message = Messages.OK,
                    IsSuccess = true,
                    Object = user.Subscriptions
                };
            }

            



        }
    }
}
