using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni1_3
{
    internal class DatabaseSingletone
    {
        private static SqlConnection conn = null;

        private DatabaseSingletone() 
        {
            
        }

        public static SqlConnection GetInstance()
        {
            if(conn == null)
            {
                SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
                consStringBuilder.UserID = "SA"; //prihlasovaci jmeno
                consStringBuilder.Password = "student"; //heslo
                consStringBuilder.InitialCatalog = "test"; //jmeno databaze
                consStringBuilder.DataSource = "PC964"; //XXX je cislo vaseho PC ve skole
                consStringBuilder.ConnectTimeout = 30;
                conn = new SqlConnection(consStringBuilder.ConnectionString);
            }
            return conn;
        }
        public static void CloseConnection()
        {
            if(conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
        }
        private static string ReadSetting(string key) 
        {
            //nemam opsane

        }
    }
}
