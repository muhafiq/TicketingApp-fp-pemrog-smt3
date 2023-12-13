using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using TicketingApp.Models.Context;
using TicketingApp.Models.Entity;

namespace TicketingApp.Models.Repository
{
    public class StageRepository
    {
        private MySqlConnection _conn;
        public StageRepository(DbContext context)
        {
            _conn = context.Conn;
        }


        public List<Stage> ReadStageEvent(string eventId)
        {
            List<Stage> list = new List<Stage>();
            string query = @"SELECT * FROM stage WHERE event_id=@event_id";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@event_id", eventId);
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            //var eachStage = new Stage();
                            //eachStage.Id = Convert.ToInt32(dtr["event_id"]);
                            //eachStage.NamaEvent = dtr["nama"].ToString();
                            //eachStage.Jenis = dtr["jenis"].ToString();
                            //eachStage.Tanggal = dtr["tanggal"].ToString();
                            //eachStage.Lokasi = dtr["lokasi"].ToString();

                            //list.Add(eachStage);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
            }
            return list;

        } 

    }
}
