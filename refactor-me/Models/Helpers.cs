using System;
using System.Data.SqlClient;
using System.Web;

namespace refactor_me.Models
{
    public class Helpers
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DataDirectory}\Database.mdf;Integrated Security=True";
        public static SqlConnection NewConnection()
        {
            var connstr = ConnectionString.Replace("{DataDirectory}", HttpContext.Current.Server.MapPath("~/App_Data"));
            return new SqlConnection(connstr);
        }
        public static int ExecuteQuery(string query)
        {
            try
            {
                var conn = Helpers.NewConnection();
                var cmd = new SqlCommand(query, conn);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
        public static SqlDataReader ExecuteReader(string query)
        {
            try
            {
                var conn = Helpers.NewConnection();
                var cmd = new SqlCommand(query, conn);
                conn.Open();
                var rdr = cmd.ExecuteReader();
                return rdr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}