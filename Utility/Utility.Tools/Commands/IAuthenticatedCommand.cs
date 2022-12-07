using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Tools.Commands
{
    public interface IAuthenticatedCommand:ICommand
    {
        Guid UserId { get; set; }
    }
}
