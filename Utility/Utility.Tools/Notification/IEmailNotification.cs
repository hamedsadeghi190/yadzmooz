using System.Threading.Tasks;

namespace Utility.Tools.Notification
{
    public interface IEmailNotification
    {
        Task<string> SendAsync(string Text,string Destination);
    }
}
