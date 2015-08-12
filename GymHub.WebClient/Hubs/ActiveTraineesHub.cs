using GymHub.WebClient.Infrastructure.SignalR;
using Microsoft.AspNet.SignalR;

namespace GymHub.WebClient.Hubs
{
    public class ActiveTraineesHub : Hub
    {
        public ActiveTraineesHub()
        {
            //We create a singleton instance of PushMessaging
            PushMessaging.GetInstance();
        }

        public static void DispatchToClient()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ActiveTraineesHub>();
            context.Clients.All.broadcastMessage("Refresh Table");
        }

    }
}