using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;

namespace TicketingApp.Models.Context
{
    public class DbContext : IDisposable
    {

        private MySqlConnection _conn;

        public MySqlConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }

        private MySqlConnection GetOpenConnection()
        {
            MySqlConnection conn = null;

            try
            {
                string connectionString = "Server=127.0.0.1;Database=ticketingapp;Uid=root;Pwd=root;";

                conn = new MySqlConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Open connection error : {0}", ex.Message);
            }
            return conn;
        }

        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                   if(_conn.State != ConnectionState.Closed) _conn.Close(); 
                }
                finally
                {
                    _conn.Dispose();
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}
