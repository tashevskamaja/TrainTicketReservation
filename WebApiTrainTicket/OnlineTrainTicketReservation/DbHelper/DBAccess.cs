using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Data.SqlClient;

namespace OnlineTrainTicketReservation.DbHelper
{
    class DBAccess
    {
        public static SqlConnection GetOpenConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineTrainTicketReservationDB"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            return conn;
        }
    }
}
