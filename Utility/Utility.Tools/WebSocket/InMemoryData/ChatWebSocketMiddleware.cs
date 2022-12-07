using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Utility.Tools.WebSocket.InMemoryData
{
    public class ChatWebSocketMiddleware
    {
        private static ConcurrentDictionary<string, System.Net.WebSockets.WebSocket> _sockets = new ConcurrentDictionary<string, System.Net.WebSockets.WebSocket>();

        private readonly RequestDelegate _next;

        public ChatWebSocketMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //if (!context.WebSockets.IsWebSocketRequest)
            //{
            //    await _next.Invoke(context);
            //    return;
            //}

            CancellationToken ct = CancellationToken.None;
            CancellationTokenSource source = new CancellationTokenSource(1000000000);
            System.Net.WebSockets.WebSocket currentSocket = await context.WebSockets.AcceptWebSocketAsync();
            var socketId = Guid.NewGuid().ToString();

            _sockets.TryAdd(socketId, currentSocket);

            while (true)
            {
                //if (ct.IsCancellationRequested)
                //{
                //    break;
                //}

                var response = await ReceiveStringAsync(currentSocket, source.Token);
                //if (string.IsNullOrEmpty(response))
                //{
                //    //if (currentSocket.State != WebSocketState.Open)
                //    //{
                //    //    break;
                //    //}

                //    //continue;
                //}
                //else
                //{
                //    SocketData received = Agent.FromJson<SocketData>(response);

                //    if (received.CMD == 1)
                //    {
                //        var kar = Agent.FromJson<CMD1>(received.Object);
                //        if (!InMemory.Kargozari.Any(p => p.KargozariId == kar.KargozariId))
                //        {
                //            InMemory.Kargozari.Add(new KargozariMap { CanSend = false, KargozariId = kar.KargozariId, ChangedDeliveries = new List<DeliverySocket> { }, Socket = currentSocket });
                //        }
                //    }
                //}
                //Console.WriteLine("Sockets : " + _sockets.Count);
                foreach (var socket in _sockets)
                {
                    //if (socket.Value.State != WebSocketState.Open)
                    //{
                    //    //continue;
                    //}
                    //else
                    {
                        //await SendStringAsync(socket.Value, "aaaaa",ct);
                        foreach (var p in InMemory.Kargozari)
                        {
                            Console.WriteLine($"Count = {p.ChangedDeliveries.Count}");

                            if (p.ChangedDeliveries.Count > 0)
                            {
                                p.CanSend = false;
                                string data = Agent.ToJson(
                                        new
                                        {
                                            CMD = 1,
                                            Object = Agent.ToJson(p.ChangedDeliveries)
                                        });
                                if (socket.Value.State == WebSocketState.Open)
                                {
                                    await SendStringAsync(socket.Value, data, source.Token);
                                    p.ChangedDeliveries = new List<DeliverySocket> { };
                                }
                            }
                        }
                    }

                }
            }

            System.Net.WebSockets.WebSocket dummy;
            _sockets.TryRemove(socketId, out dummy);

            await currentSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", ct);
            currentSocket.Dispose();
        }

        private static Task SendStringAsync(System.Net.WebSockets.WebSocket socket, string data, CancellationToken ct = default(CancellationToken))
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            var segment = new ArraySegment<byte>(buffer);
            return socket.SendAsync(segment, WebSocketMessageType.Text, true, ct);
        }

        private static async Task<string> ReceiveStringAsync(System.Net.WebSockets.WebSocket socket, CancellationToken ct = default(CancellationToken))
        {
            //await SendStringAsync(socket, "salam");
            var buffer = new ArraySegment<byte>(new byte[8192]);
            using (var ms = new MemoryStream())
            {
                WebSocketReceiveResult result;
                do
                {
                    ct.ThrowIfCancellationRequested();

                    result = await socket.ReceiveAsync(buffer, ct);
                    ms.Write(buffer.Array, buffer.Offset, result.Count);
                }
                while (!result.EndOfMessage);

                ms.Seek(0, SeekOrigin.Begin);
                if (result.MessageType != WebSocketMessageType.Text)
                {
                    return null;
                }

                // Encoding UTF8: https://tools.ietf.org/html/rfc6455#section-5.6
                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
    }
}
