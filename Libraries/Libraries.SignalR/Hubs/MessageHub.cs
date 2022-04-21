using Microsoft.AspNetCore.SignalR;

namespace Libraries.SignalR.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("SendMessage", message);
        }
    }
}
