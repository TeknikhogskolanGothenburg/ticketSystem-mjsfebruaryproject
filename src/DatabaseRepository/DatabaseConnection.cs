using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace TicketSystem.DatabaseRepository
{
    public  class DatabaseConnection
    {

        public static string ConnectionString { get; set; }

        public static SqlConnection ConnectionFactory()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
