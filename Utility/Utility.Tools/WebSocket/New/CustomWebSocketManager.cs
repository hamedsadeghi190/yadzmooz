using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Utility.Tools.WebSocket.New
{
    public class CustomWebSocketManager
    {
        private readonly RequestDelegate _next;

        public CustomWebSocketManager(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ICustomWebSocketFactory wsFactory, ICustomWebSocketMessageHandler wsmHandler)
        {
            //if (context.Request.Path == "/ws")
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    string username = context.Request.Query["u"];
                    //if (!string.IsNullOrEmpty(username))
                    {
                        System.Net.WebSockets.WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                        CustomWebSocket userWebSocket = new CustomWebSocket()
                        {
                            WebSocket = webSocket,
                            Username = Guid.NewGuid().ToString()// username
                        };
                        wsFactory.Add(userWebSocket);
                        await wsmHandler.SendInitialMessages(userWebSocket);
                        await Listen(context, userWebSocket, wsFactory, wsmHandler);
                    }
                }
                else
                {
                    context.Response.StatusCode = 400;
                }
            }
            await _next(context);
        }

        private async Task Listen(HttpContext context, CustomWebSocket userWebSocket, ICustomWebSocketFactory wsFactory, ICustomWebSocketMessageHandler wsmHandler)
        {
            System.Net.WebSockets.WebSocket webSocket = userWebSocket.WebSocket;
            var buffer = new byte[1024 * 4];
            var str = new ArraySegment<byte>(buffer);
            WebSocketReceiveResult result= await webSocket.ReceiveAsync(str, CancellationToken.None);
            string data = await GetString(webSocket, result, str);
            //await webSocket.SendAsync(str, WebSocketMessageType.Text, true, CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                //await wsmHandler.HandleMessage(result, buffer, userWebSocket, wsFactory);

                //result = await webSocket.ReceiveAsync(str, CancellationToken.None);
                //data = await GetString(webSocket, result, str);
                //await webSocket.SendAsync(str, WebSocketMessageType.Text, true, CancellationToken.None);
                //Thread.Sleep(2000);

                SocketData received = Agent.FromJson<SocketData>(data);

                if (received.CMD == 1)
                {
                    var kar = Agent.FromJson<CMD1>(received.Object);
                    if (!InMemory.Kargozari.Any(p => p.KargozariId == kar.KargozariId))
                    {
                        InMemory.Kargozari.Add(new KargozariMap { CanSend = false, KargozariId = kar.KargozariId, ChangedDeliveries = new List<DeliverySocket> { }, Socket = webSocket });
                    }
                }

                foreach (var p in InMemory.Kargozari)
                {
                    //Console.WriteLine($"Count = {p.ChangedDeliveries.Count}");

                    if (p.ChangedDeliveries.Count > 0)
                    {
                        p.CanSend = false;
                        string sentData = Agent.ToJson(
                                new
                                {
                                    CMD = 1,
                                    Object = p.ChangedDeliveries
                                });
                        var buf = Encoding.UTF8.GetBytes(sentData);
                        var segment = new ArraySegment<byte>(buf);
                        await webSocket.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
                        p.ChangedDeliveries = new List<DeliverySocket> { };
                        
                    }
                }
                //result = await webSocket.ReceiveAsync(str, CancellationToken.None);
                //data = (await GetString(webSocket, result, str)).Trim();
            }
            wsFactory.Remove(userWebSocket.Username);
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }

        private static async Task<string> GetString(System.Net.WebSockets.WebSocket webSocket, WebSocketReceiveResult result, ArraySegment<byte> str)
        {
            using (var ms = new MemoryStream())
            {
                do
                {
                    ms.Write(str.Array, str.Offset, result.Count);
                }
                while (!result.EndOfMessage);

                ms.Seek(0, SeekOrigin.Begin);


                // Encoding UTF8: https://tools.ietf.org/html/rfc6455#section-5.6
                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    return await reader.ReadToEndAsync();                    
                }
            }
        }
    }
}
