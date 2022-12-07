using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Tools.WebSocket.New
{
    class CustomWebSocketMessage
    {
        public string Text { get; set; }
        public DateTime MessagDateTime { get; set; }
        public string Username { get; set; }
        public WSMessageType Type { get; set; }
    }
}
