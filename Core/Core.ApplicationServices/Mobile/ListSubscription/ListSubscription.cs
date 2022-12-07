using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using Core.Mongo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class ListSubscription : IListSubscription
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public ListSubscription
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public ListSubscriptionResultDto Execute(ListSubscriptionDto dto)
        {

            var subs = unit.Subscriptions.GetAll();

            return new ListSubscriptionResultDto 
            {
                Code = 0 ,
                IsSuccess = true,
                Message = Messages.OK,
                Object = subs.Select(p => DtoBuilder.CreateSubscriptionDto(p)).ToList(),
            };

        }
    }
}
