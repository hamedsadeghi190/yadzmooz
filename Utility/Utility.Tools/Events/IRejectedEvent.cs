using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Tools.Events
{
    public interface IRejectedEvent:IEvent
    {
        string Reason { get; }
        string Code { get;  }
    }
}
