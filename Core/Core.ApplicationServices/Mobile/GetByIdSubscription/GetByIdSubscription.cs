using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using Core.Mongo.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GetByIdSubscription : IGetByIdSubscription
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public GetByIdSubscription
            (
            IUnitOfWork unit,
             IJwtHandler jwtHandler
            )
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public GetByIdSubscriptionResultDto Execute(GetByIdSubscriptionDto dto)
        {

            var sub= unit.Subscriptions.GetById(dto.Id);
            if (sub == null)
            {
                return new GetByIdSubscriptionResultDto
                {
                    Code = 0,
                    IsSuccess = true,
                    Message = Messages.SubscriptionDoesNotExist,
                    Object = null
                };
            }
            else
            {
                return new GetByIdSubscriptionResultDto
                {
                    Code = 0,
                    IsSuccess = true,
                    Message = Messages.OK,
                    Object = sub
                };
            }
            

        }
    }
}
