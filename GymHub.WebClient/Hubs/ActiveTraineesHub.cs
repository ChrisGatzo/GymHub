using Microsoft.AspNet.SignalR;

namespace GymHub.WebClient.Hubs
{
    public class ActiveTraineesHub : Hub
    {       
        public static void DispatchToClient()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ActiveTraineesHub>();
            context.Clients.All.broadcastMessage("Refresh Table");
        }

    }
}