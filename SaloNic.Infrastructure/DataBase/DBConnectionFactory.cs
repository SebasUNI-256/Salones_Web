using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Infrastructure.DataBase
{
    public class DBConnectionFactory
    {
        private readonly string _ConnectionString;

        public DBConnectionFactory(string connectionString)
            {
            _ConnectionString = connectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_ConnectionString);
        }
        
    }
}
