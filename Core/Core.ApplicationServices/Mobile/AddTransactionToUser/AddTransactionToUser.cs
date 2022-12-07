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
    public class AddTransactionToUser : IAddTransactionToUser
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public AddTransactionToUser
            (
            IUnitOfWork unit,
             IJwtHandler jwtHandler
            )
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public AddTransactionToUserResultDto Execute(AddTransactionToUserDto dto)
        {

            var tran= unit.Transactions.GetByOrderId(dto.OrderId);
            var sub= unit.Subscriptions.GetById(tran.SubscriptionId);

            if (dto.Status == TransactionStatus.Success.ToInt())
            {
                tran.Status = TransactionStatus.Success.ToInt();

                unit.Transactions.Replace(tran);

                var user = unit.Users.GetById(tran.UserId);
             
                user.SubscriptionExpireDate = DateTime.Now.AddMonths(sub.ExpireMonths).ToUnix();
                unit.Users.Update(user);

            }
            else if(dto.Status == TransactionStatus.Failed.ToInt())
            {
                tran.Status = TransactionStatus.Failed.ToInt();

                unit.Transactions.Replace(tran);
            }

            return new AddTransactionToUserResultDto
            {
                Code = 0,
                IsSuccess = true,
                Message = Messages.OK
            };
            
            

        }
    }
}
