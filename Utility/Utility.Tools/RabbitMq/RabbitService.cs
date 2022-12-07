using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//namespace Utility.Tools.RabbitMq
//{
//    public interface IRabbitService
//    {
//        bool Send(string QueueName, string Message, string RoutingKey);
//        delegate void Receive(string QueueName, string RoutingKey);        
//    }
//    public class RabbitService : IRabbitService
//    {
//        private readonly IConfiguration config;

//        public RabbitService(IConfiguration config)
//        {
//            this.config = config;
//        }
//        public bool Send(string QueueName, string Message, string RoutingKey)
//        {
//            var option = new RabbitMqOptions();
//            var section = config.GetSection("rabbitmq");
//            section.Bind(option);
//            var factory = new ConnectionFactory() { HostName = option.Hostnames[0], UserName = option.Username, Password = option.Password };
//            try
//            {
//                using (var connection = factory.CreateConnection())
//                using (var channel = connection.CreateModel())
//                {
//                    channel.QueueDeclare(queue: QueueName,
//                                         durable: false,
//                                         exclusive: false,
//                                         autoDelete: false,
//                                         arguments: null);

//                    string message = Message;
//                    var body = Encoding.UTF8.GetBytes(message);

//                    channel.BasicPublish(exchange: "",
//                                         routingKey: RoutingKey,
//                                         basicProperties: null,
//                                         body: body);
//                    return true;
//                }

//            }
//            catch (Exception e1)
//            {
//                return false;
//            }
//        }

//        public void Receive(string QueueName, string RoutingKey)
//        {
//            var option = new RabbitMqOptions();
//            var section = config.GetSection("rabbitmq");
//            section.Bind(option);
//            var factory = new ConnectionFactory() { HostName = option.Hostnames[0]};
//            using (var connection = factory.CreateConnection())
//            using (var channel = connection.CreateModel())
//            {
//                channel.QueueDeclare(queue: QueueName,
//                                     durable: false,
//                                     exclusive: false,
//                                     autoDelete: false,
//                                     arguments: null);

//                var consumer = new EventingBasicConsumer(channel);
//                consumer.Received += (model, ea) =>
//                {
//                    var body = ea.Body;
//                    var message = Encoding.UTF8.GetString(body.ToArray());
//                };
//                channel.BasicConsume(queue: RoutingKey,
//                                     autoAck: true,
//                                     consumer: consumer);

//            }
//        }
//    }
//}
