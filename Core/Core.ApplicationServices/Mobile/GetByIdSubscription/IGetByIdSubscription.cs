using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IGetByIdSubscription : IApplicationService
    {
        GetByIdSubscriptionResultDto Execute(GetByIdSubscriptionDto dto);
    }
}


