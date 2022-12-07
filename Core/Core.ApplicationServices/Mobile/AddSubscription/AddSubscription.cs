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
    public class AddSubscription : IAddSubscription
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public AddSubscription
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public AddSubscriptionResultDto Execute(AddSubscriptionDto dto)
        {

            unit.Subscriptions.Insert(new Subscription
            {
                CreatedAt = Agent.Now,
                Icon = dto.Icon,
                Title = dto.Title,
                Id = new Guid(),
                DiscountPercent = dto.DiscountPercent,
                ExpireMonths = dto.ExpireMonths,
                NumberOfDevice  = dto.NumberOfDevice,
                Price = dto.Price,
            });

            return new AddSubscriptionResultDto
            {
                Code = 0 ,
                IsSuccess = true,
                Message = Messages.Success
            };

        }
    }
}
