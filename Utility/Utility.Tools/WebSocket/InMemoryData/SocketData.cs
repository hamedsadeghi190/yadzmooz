using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Tools.WebSocket
{
    public class SocketData
    {
        public int CMD { get; set; }
        public string Object { get; set; }
    }

    public class CMD1
    {
        public int KargozariId { get; set; }
    }

    public class DeliverySocket
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Name{ get; set; }
        public string Image{ get; set; }
        public Guid DeliveryId{ get; set; }
        public int Status{ get; set; }
    }
}
