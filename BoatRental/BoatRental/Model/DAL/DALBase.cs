using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BoatRental.Model.DAL
{
    public class DALBase
    {
        private static string _connectionString;

        protected static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["BoatDBString"].ConnectionString;
        }
    }
}