using Microsoft.AspNet.SignalR;

namespace GymHub.WebClient.Hubs
{
    public class ActiveAthletesHub : Hub
    {       
        public static void DispatchToClient()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ActiveAthletesHub>();
            context.Clients.All.broadcastMessage("Refresh Table");
        }

    }
}