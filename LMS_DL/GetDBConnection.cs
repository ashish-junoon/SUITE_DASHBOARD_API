using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_DL
{
    public static class GetDBConnection
    {
        public static  SqlConnection getConnection(string configuration)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = configuration;
            return sqlConnection;
        }
    }
}
