//using RawRabbit;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
//using RawRabbit.Instantiation;
using Utility.Tools.Commands;
using Utility.Tools.Events;
using RabbitMQReiverCoreAPI.RebbitMQ;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Utility.Tools.General;
using System.Text;
using System.Collections.Generic;
using System;
using RabbitMQ.Client.Events;

namespace Utility.Tools.RabbitMq.New
{
    public static class Extension
    {
        public static void AddRabbitMq(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<RabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<RabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = "37.255.249.203",
                    UserName = "hiwa_mn",
                    Password = "Hirad1858"
                };
                return new RabbitMQPersistentConnection(factory);
            });
        }
    }

    public static class ApplicationBuilderExtentions
    {
        public static RabbitMQPersistentConnection Listener { get; set; }

        public static IApplicationBuilder UseRabbitListener(this IApplicationBuilder app, IConfiguration configuration)
        {
            configuration.GetSection<Queue>();
            Listener = app.ApplicationServices.GetService<RabbitMQPersistentConnection>();
            var life = app.ApplicationServices.GetService<IApplicationLifetime>();
            life.ApplicationStarted.Register(OnStarted);

            //press Ctrl+C to reproduce if your app runs in Kestrel as a console app
            life.ApplicationStopping.Register(OnStopping);
            return app;
        }

        private static void OnStarted()
        {
            Listener.CreateConsumerChannel(Queue.Name);
        }

        private static void OnStopping()
        {
            Listener.Disconnect();
        }
    }


    public interface IHandleRabbit
    {
        void Send(string queueName, string routingKey, object data);
    }

    public class HandleRabbit : IHandleRabbit
    {
        public void Send(string queueName, string routingKey, object data)
        {
            var factory = new ConnectionFactory() { HostName = "37.255.249.203", UserName = "hiwa_mn", Password = "Hirad1858" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                //channel.ExchangeDeclare(exchange: "Hiwa", type: ExchangeType.Direct);
                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.DeliveryMode = 2;
                //properties.Headers = new Dictionary<string, object>();
                //properties.Headers.Add("senderUniqueId", senderUniqueId);//optional unique sender details in receiver side              
                //properties.Expiration = "36000000";
                //properties.ContentType = "text/plain";
                var message = Agent.ToJson(data);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "logs",
                                     routingKey: "",
                                     basicProperties: properties,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }



            //var factory = new ConnectionFactory() { HostName = "37.255.249.203", UserName = "hiwa_mn", Password = "Hirad1858" ,Port = 5672};
            //var connection = factory.CreateConnection();



            //using (var channel = connection.CreateModel())
            //{

            //    //channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            //    //channel.QueueBind(queueName, "Hiwa", routingKey);


            //    string message = Agent.ToJson(data);

            //    var body = Encoding.UTF8.GetBytes(message);

            //    IBasicProperties properties = channel.CreateBasicProperties();
            //    properties.Persistent = true;
            //    properties.DeliveryMode = 2;
            //    //properties.Headers = new Dictionary<string, object>();
            //    //properties.Headers.Add("senderUniqueId", senderUniqueId);//optional unique sender details in receiver side              
            //    //properties.Expiration = "36000000";
            //    //properties.ContentType = "text/plain";

            //    //channel.ConfirmSelect();

            //    channel.BasicPublish(exchange: "",
            //                         routingKey: routingKey,
            //                         basicProperties: properties,
            //                         body: body);

            //    //channel.WaitForConfirmsOrDie();

            //    //channel.BasicAcks += (sender, eventArgs) =>
            //    //{
            //    //    Console.WriteLine("*********ACK************");
            //    //};
            //    //channel.ConfirmSelect();

            //}



            //-------------------------  Receiving feedback ---------------------------------------------------------------------------------

            //using (var channel = connection.CreateModel())
            //{
            //    channel.QueueDeclare(queue: queueName,
            //                       durable: false,
            //                       exclusive: false,
            //                       autoDelete: false,
            //                       arguments: null);

            //    var consumer = new EventingBasicConsumer(channel);
            //    consumer.Received += (model, ea) =>
            //    {
            //        IDictionary<string, object> headers = ea.BasicProperties.Headers; // get headers from Received msg

            //        foreach (KeyValuePair<string, object> header in headers)
            //        {
            //            //if (senderUniqueId == Encoding.UTF8.GetString((byte[])header.Value))// Get feedback message only for me
            //            {
            //                var body = ea.Body;
            //                var message = Encoding.UTF8.GetString(body.ToArray());
            //                Console.WriteLine(message);
            //            }
            //        }
            //    };

            //    channel.BasicConsume(queue: queueName,
            //                         autoAck: true,
            //                         consumer: consumer);



            //}
        }
    }
}
