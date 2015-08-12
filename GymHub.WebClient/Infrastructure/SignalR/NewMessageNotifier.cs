using System.Data;
using System.Data.SqlClient;

namespace GymHub.WebClient.Infrastructure.SignalR
{
    public delegate void ResultChangedEventHandler(object sender, SqlNotificationEventArgs e);

    public class NewMessageNotifier
    {
        public event ResultChangedEventHandler NewMessage;
        readonly string _connString;
        readonly string _selectQuery;

        internal NewMessageNotifier(string connString, string selectQuery)
        {
            _connString = connString;
            _selectQuery = selectQuery;
            RegisterForNotifications();
        }

        private void RegisterForNotifications()
        {
            using (var connection = new SqlConnection(_connString))
            {
                using (var command = new SqlCommand(_selectQuery, connection))
                {
                    command.Notification = null;
                    var dependency = new SqlDependency(command);
                    dependency.OnChange += dependency_OnChange;
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    command.ExecuteReader();
                }
            }
        }
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (NewMessage != null)
                NewMessage(sender, e);
            //subscribe again to notifier
            RegisterForNotifications();
        }
    }
}