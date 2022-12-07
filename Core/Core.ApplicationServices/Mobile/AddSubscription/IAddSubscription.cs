using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IAddSubscription : IApplicationService
    {
        AddSubscriptionResultDto Execute(AddSubscriptionDto dto);
    }
}


