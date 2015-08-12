using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using GymHub.WebClient.Hubs;

namespace GymHub.WebClient.Infrastructure.SignalR
{
    class PushMessaging
    {
        static PushMessaging _instance;

        public static void GetInstance()
        {
            if (_instance == null)
                _instance = new PushMessaging();
        }

        private PushMessaging()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["GymHubDBContext"].ConnectionString;
            var entityConnectionStringBuilder = new EntityConnectionStringBuilder(connectionString);
            var connString = entityConnectionStringBuilder.ProviderConnectionString;

            const string selectQuery = @"SELECT [Id], [FirstName], [LastName] FROM [dbo].[Trainees]";
            var newMessageNotifier = new NewMessageNotifier(connString, selectQuery);
            newMessageNotifier.NewMessage += NewMessageRecieved;
        }

        private static void NewMessageRecieved(object sender, SqlNotificationEventArgs e)
        {
            ActiveTraineesHub.DispatchToClient();
        }
    }
}