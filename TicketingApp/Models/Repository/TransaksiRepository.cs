using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TicketingApp.Models.Context;
using TicketingApp.Models.Entity;
using MySqlConnector;

namespace TicketingApp.Models.Repository
{
    public class TransaksiRepository
    {
        private MySqlConnection _conn;
        public TransaksiRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int CreateTransaksi(List<Transaksi> newTransaksi)
        {
            int result = 0;
            string query = @"INSERT INTO transaksi(transaksi_id, user_id, event_id, stage_id, total_harga)
                            VALUES (@id, @user_id, @event_id, @stage_id, @total)";

            foreach(var transaksi in newTransaksi) {
                using (MySqlCommand cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@id", transaksi.Id);
                    cmd.Parameters.AddWithValue("@user_id", transaksi.UserPembeli.Id);
                    cmd.Parameters.AddWithValue("@event_id", transaksi.TicketDibeli.Id);
                    cmd.Parameters.AddWithValue("@stage_id", transaksi.StageDipilih.Id);
                    cmd.Parameters.AddWithValue("@total", transaksi.Bayar);

                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                    }
                }

            }

            return result;
        }

        public List<Transaksi> ReadRiwayatTransaksi()
        {
            //List<Transaksi> list = new List<Transaksi>();
            throw new NotImplementedException();
        }
    }
}
