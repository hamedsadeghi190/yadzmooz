using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utility.Tools.Auth
{
    public interface IEncrypter
    {
        string GetSalt();
        string GetHash(string value,string salt);
    }
}
