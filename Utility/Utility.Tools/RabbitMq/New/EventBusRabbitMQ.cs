using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.RabbitMq.New;

namespace RabbitMQReiverCoreAPI.RebbitMQ
{
    public class EventBusRabbitMQ : IDisposable
    {
        private readonly IRabbitMQPersistentConnection _persistentConnection;
        private IModel _consumerChannel;
        private string _queueName;

        public EventBusRabbitMQ(IRabbitMQPersistentConnection persistentConnection, string queueName = null)
        {
            _persistentConnection = persistentConnection ?? throw new ArgumentNullException(nameof(persistentConnection));
            _queueName = queueName;
        }

        public IModel CreateConsumerChannel()
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }
            Console.WriteLine("***********************" + _queueName);
            var channel = _persistentConnection.CreateModel();
            //channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            //channel.QueueBind(queue: _queueName,
            //      exchange: "Hiwa",
            //      routingKey: "");
            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(queue: _queueName, autoAck: false, consumer: consumer);

            //consumer.Received += (model, e) =>
            //{
            //    //var eventName = e.RoutingKey;
            //    var message = Encoding.UTF8.GetString(e.Body.ToArray());
            //    Console.WriteLine("******************" + message);
            //    //channel.BasicAck(e.DeliveryTag, multiple: false);
            //};

            //Create event when something receive
            consumer.Received += ReceivedEvent;



            channel.CallbackException += (sender, ea) =>
            {
                Console.WriteLine("***************************exception");
                //_consumerchannel.dispose();
                //_consumerchannel = createconsumerchannel();
            };
            return channel;
        }

        private void ReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            //var eventName = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body.ToArray());
            Console.WriteLine("******************" + message);
            //channel.BasicAck(e.DeliveryTag, multiple: false);
            Console.WriteLine("*************************************************");
         
            if (e.RoutingKey == "b")
            {
                PublishUserSaveFeedback("a", new { Key = "Hi" }, e.BasicProperties.Headers);
            }

        }

        public void PublishUserSaveFeedback(string _queueName,object publishModel, IDictionary<string, object> headers)
        {           

            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            using (var channel = _persistentConnection.CreateModel())
            {

                channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                var message = JsonConvert.SerializeObject(publishModel);
                var body = Encoding.UTF8.GetBytes(message);

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.DeliveryMode = 2;
                properties.Headers = headers;
                // properties.Expiration = "36000000";
                //properties.ContentType = "text/plain";

                //channel.ConfirmSelect();
                channel.BasicPublish(exchange: "", routingKey: _queueName, mandatory: true, basicProperties: properties, body: body);
                //channel.WaitForConfirmsOrDie();

                //channel.BasicAcks += (sender, eventArgs) =>
                //{
                //    Console.WriteLine("Sent RabbitMQ");
                //    //implement ack handle
                //};
                //channel.ConfirmSelect();
            }
        }

        public void Dispose()
        {
            if (_consumerChannel != null)
            {
                _consumerChannel.Dispose();
            }
        }
    }
}
