
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utility.Tools.Events
{
    public class ActivityCreatedHandler : IEventHandler<ActivityCreated>
    {
        

        public ActivityCreatedHandler()
        {

        }
        public async Task HandleAsync(ActivityCreated @event)
        {

            await Task.CompletedTask;
            Console.WriteLine("*****************");
            Console.WriteLine($" {@event.Name}");
            //await bus.PublishAsync(new UserCreated("Zanyar", $"{int.Parse(@event.Name) + 1}"));
        }
    }
}
