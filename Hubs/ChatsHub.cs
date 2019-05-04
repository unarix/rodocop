// using Microsoft.AspNetCore.SignalR;
// using System.Threading.Tasks;

// namespace rodocop.Hubs
// {
//     public class ChatHub : Hub
//     {
//         public async Task SendMessage(string user, string message)
//         {
//             await Clients.All.SendAsync("ReceiveMessage", user, message);
//         }
//     }
// }

using Microsoft.AspNetCore.SignalR;

namespace rodocop.Hubs
{

    public class Chat : Hub
    {
        public void BroadcastMessage(string name, string message)
        {
            Clients.All.SendAsync("broadcastMessage", name, message);
        }

        public void Echo(string name, string message)
        {
            Clients.Client(Context.ConnectionId).SendAsync("echo", name, message + " (echo from server)");
        }
    }
}