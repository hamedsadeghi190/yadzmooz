using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Tools.Auth
{
    public interface IJwtHandler
    {
        JsonWebToken Create(Guid userId);
        JsonWebToken CreateToken(Guid userId, List<string> roles);
    }
}
