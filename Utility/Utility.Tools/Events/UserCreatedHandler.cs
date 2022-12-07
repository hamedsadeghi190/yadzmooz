using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utility.Tools.Events
{
    public class UserCreatedHandler : IEventHandler<UserCreated>
    {
        

        public UserCreatedHandler()
        {
        }
        public async Task HandleAsync(UserCreated @event)
        {
            
            await Task.CompletedTask;
            Console.WriteLine("*****************");
            Console.WriteLine($"{@event.Name}");
        }
    }
}
