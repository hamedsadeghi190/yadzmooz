using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Utility.Tools.WebSocket;

namespace Utility.Tools.WebSocket
{
    public class KargozariMap
    {
        public System.Net.WebSockets.WebSocket Socket { get; set; }
        public CancellationToken Token { get; set; }
        public bool CanSend { get; set; }
        public int KargozariId { get; set; }
        public List<DeliverySocket> ChangedDeliveries{ get; set; }
    }

    public class InMemory
    {
        public static List<KargozariMap> Kargozari { get; set; } = new List<KargozariMap> { };
    }
}
