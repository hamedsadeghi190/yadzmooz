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
    public class GetUsers : IGetUsers
    {
        private readonly IUnitOfWork unit;
        private readonly INotification notification;
        private readonly IConfiguration configuration;

        public GetUsers
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


        public GetUsersResultDto Execute(GetUsersDto dto)
        {




            return new GetUsersResultDto
            {
                Code = 0,
                IsSuccess = true,
                Message = Messages.OK,
                Object = unit.Users.GetAll().Select(p => DtoBuilder.CreateUserDto(p)).ToList(),
            };

        }
    }
}
