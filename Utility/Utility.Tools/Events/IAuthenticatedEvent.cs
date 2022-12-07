using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Tools.Events
{
    public interface IAuthenticatedEvent : IEvent
    {
        Guid UserId { get; }
    }
}

