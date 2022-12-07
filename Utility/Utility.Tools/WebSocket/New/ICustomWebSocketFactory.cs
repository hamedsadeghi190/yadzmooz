using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Tools.WebSocket.New
{
    public interface ICustomWebSocketFactory
    {
        void Add(CustomWebSocket uws);
        void Remove(string username);
        List<CustomWebSocket> All();
        List<CustomWebSocket> Others(CustomWebSocket client);
        CustomWebSocket Client(string username);
    }
}
