//using RawRabbit;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
//using RawRabbit.Instantiation;
using Utility.Tools.Commands;
using Utility.Tools.Events;

namespace Utility.Tools.RabbitMq
{
    //public static class Extensions
    //{
        
    //   public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
    //        ICommandHandler<TCommand> handler) where TCommand : ICommand
    //        => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
    //            context => context.UseSubscribeConfiguration(
    //                config => config.FromDeclaredQueue(
    //                    queue => queue.WithName(GetQueueName<TCommand>()))));

    //    // Event Handler Extension Method
    //    public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
    //        IEventHandler<TEvent> handler) where TEvent : IEvent
    //        => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
    //            context => context.UseSubscribeConfiguration(
    //                config => config.FromDeclaredQueue(
    //                    queue => queue.WithName(GetQueueName<TEvent>()))));


    //    private static string GetQueueName<T>() => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";

    //    public static void AddRabbitMq(this IServiceCollection service, IConfiguration config)
    //    {
    //        var option = new RabbitMqOptions();
    //        var section = config.GetSection("rabbitmq");
    //        section.Bind(option);
    //        var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
    //        {
    //            ClientConfiguration = option
    //        });
    //        service.AddSingleton<IBusClient>(_=> client);
    //    }
    //}
}
