using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.Models.Entity;
using TicketingApp.Models.Context;
using MySqlConnector;

namespace TicketingApp.Models.Repository
{
    class EventRepository
    {
        private MySqlConnection _conn;
        public EventRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public List<Event> ReadAllEvents(int offset)
        {
            List<Event> list = new List<Event>();
            string query = @"SELECT * FROM event LIMIT 20 OFFSET @offset";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@offset", offset);
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            var eachEvent = new Event();
                            eachEvent.Id = Convert.ToInt32(dtr["event_id"]);
                            eachEvent.NamaEvent = dtr["nama"].ToString();
                            eachEvent.Jenis = dtr["jenis"].ToString();
                            eachEvent.Tanggal = dtr["tanggal"].ToString();
                            eachEvent.Lokasi = dtr["lokasi"].ToString();

                            list.Add(eachEvent);
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

        public List<Event> ReadPopularEvents()
        {
            throw new NotImplementedException();
        }

        public List<Event> GetEventBySearch(string content)
        {
            List<Event> list = new List<Event>();
            string query = @"SELECT * FROM event WHERE nama LIKE %@content%";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@content", content);
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            var eachEvent = new Event();
                            eachEvent.Id = Convert.ToInt32(dtr["event_id"]);
                            eachEvent.NamaEvent = dtr["nama"].ToString();
                            eachEvent.Jenis = dtr["jenis"].ToString();
                            eachEvent.Tanggal = dtr["tanggal"].ToString();
                            eachEvent.Lokasi = dtr["lokasi"].ToString();

                            list.Add(eachEvent);
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

        public int AddEvent(Event newEvent)
        {
            int result = 0;
            string query = @"INSERT INTO event (nama, jenis, tanggal, lokasi, user_id) VALUES (@nama, @jenis, @tanggal, @lokasi, @user_id)";

            using (MySqlCommand cmd = new MySqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@nama", newEvent.NamaEvent);
                cmd.Parameters.AddWithValue("@jenis", newEvent.Jenis);
                cmd.Parameters.AddWithValue("@tanggal", newEvent.Tanggal);
                cmd.Parameters.AddWithValue("@lokasi", newEvent.Lokasi);
                cmd.Parameters.AddWithValue("@user_id", newEvent.UserId);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }
            return result;
        }

        public int UpdateEvent(Event eventToUpdate)
        {
            int result = 0;
            string query = @"UPDATE event SET nama=@nama, jenis=@jenis, tanggal=@tanggal, lokasi=@lokasi WHERE event_id=@id";

            using (MySqlCommand cmd = new MySqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@nama", eventToUpdate.NamaEvent);
                cmd.Parameters.AddWithValue("@jenis", eventToUpdate.Jenis);
                cmd.Parameters.AddWithValue("@tanggal", eventToUpdate.Tanggal);
                cmd.Parameters.AddWithValue("@lokasi", eventToUpdate.Lokasi);
                cmd.Parameters.AddWithValue("@id", eventToUpdate.Id);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }
            return result;
        }

        public int DeleteEvent(Event eventToDelete)
        {
            int result = 0;
            string query = @"DELETE FROM event WHERE event_id=@id";

            using (MySqlCommand cmd = new MySqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@id", eventToDelete.Id);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }
            return result;
        }


    }
}
