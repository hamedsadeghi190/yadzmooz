using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Utility.Tools.WebSocket
{
    public class WebSocketMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        

        public WebSocketMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<WebSocketMiddleware>();
        }

        [Obsolete]
        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("Handling request: " + httpContext.Request.Path);

            
            if (httpContext.WebSockets.IsWebSocketRequest)
            {
                var webSocket = await httpContext.WebSockets.AcceptWebSocketAsync();
                
                while (webSocket.State == WebSocketState.Open)
                {                    
                    var token = CancellationToken.None;
                    var buffer = new ArraySegment<Byte>(new Byte[4096]);
                    var received = await webSocket.ReceiveAsync(buffer, token);

                    switch (received.MessageType)
                    {
                        case WebSocketMessageType.Text:
                            await HandleMessage(webSocket, buffer, token);
                            break;
                        case WebSocketMessageType.Close:
                            CloseConnection(webSocket, buffer, token);
                            break;
                    }
                }
            }
            else
            {
                await _next.Invoke(httpContext);
            }

            _logger.LogInformation("Finished handling request.");
        }

        private void CloseConnection(System.Net.WebSockets.WebSocket webSocket, ArraySegment<byte> buffer, CancellationToken token)
        {
            Encoding.UTF8.GetString(buffer.Array, buffer.Offset, buffer.Count);
            var result = Encoding.Default.GetString(buffer).Trim();
            Console.WriteLine("Close" + result);
        }

        [Obsolete]
        private static async Task HandleMessage(System.Net.WebSockets.WebSocket webSocket, ArraySegment<byte> buffer, CancellationToken token)
        {
            Encoding.UTF8.GetString(buffer.Array, buffer.Offset, buffer.Count);
            var type = WebSocketMessageType.Text;
            var result = Encoding.Default.GetString(buffer).Trim();
            Console.WriteLine(result);
            SocketData received = Agent.FromJson<SocketData>(result);
            
            if (received.CMD == 1)
            {
                if (!InMemory.Kargozari.Any(p => p.Token.WaitHandle.Handle.ToInt32() == token.WaitHandle.Handle.ToInt32()))
                {
                    var kar = Agent.FromJson<CMD1>(received.Object);
                    
                    InMemory.Kargozari.Add(new KargozariMap { CanSend = false,KargozariId = kar.KargozariId,Token = token,ChangedDeliveries = new List<DeliverySocket> { },Socket = webSocket});
                }
            }
            //var data = Encoding.UTF8.GetBytes(
            //    Agent.ToJson(
            //        new
            //        {
            //            CMD = 1,
            //            Object = Agent.ToJson(new List<DeliverySocket> {
            //            new DeliverySocket() {
            //                Name = "پیک 1",
            //                Lat = 39,
            //                Lon = 51,
            //                Status = 1,
            //                DeliveryId = new Guid(),
            //                Image = "https://javascript-conference.com/wp-content/uploads/2019/10/IJS_London20_Website_Logo_Header_53632_v1.png"
            //            }})
            //        }));
            //buffer = new ArraySegment<byte>(data);
            //await webSocket.SendAsync(buffer, type, true, token);
        }
    }
}
