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
    public class EditSubscription : IEditSubscription
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public EditSubscription
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public EditSubscriptionResultDto Execute(EditSubscriptionDto dto)
        {


            var subs = unit.Subscriptions.GetById(dto.Id);

            subs.Icon = dto.Icon;
            subs.Title = dto.Title;
            subs.ExpireMonths = dto.ExpireMonths;
            subs.NumberOfDevice = dto.NumberOfDevice;
            subs.Price = dto.Price;
            subs.DiscountPercent = dto.DiscountPercent;


            unit.Subscriptions.Replace(subs);


            return new EditSubscriptionResultDto 
            {
                Code = 0 ,
                IsSuccess = true,
                Message = Messages.OK
            };

        }
    }
}
