using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task cancel(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage1", user, message);
        }


        public async Task Accept(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage2", user, message);
        }
   
    }
}