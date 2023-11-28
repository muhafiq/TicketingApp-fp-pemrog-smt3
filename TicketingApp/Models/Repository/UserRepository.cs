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
    public class UserRepository
    {
        private MySqlConnection _conn;
        public UserRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public User Login(User user)
        {
            User userToAuth = new User();
            string query = @"SELECT * FROM users WHERE email=@email";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        userToAuth.Id = Convert.ToInt32(dtr["id"]);
                        userToAuth.Nama = dtr["nama"].ToString();
                        userToAuth.Password = dtr["password"].ToString();
                        userToAuth.Email = dtr["email"].ToString();
                        userToAuth.NoTlp = dtr["no_tlp"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByNama error: {0}", ex.Message);
            }

            return userToAuth;
        }


        public int Register(User newUser)
        {
            int result = 0;
            string query = @"INSERT INTO users (nama, password, email, no_tlp) VALUES (@nama, @password, @email, @noTlp)";

            using (MySqlCommand cmd = new MySqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@nama", newUser.Nama);
                cmd.Parameters.AddWithValue("@password", newUser.Password);
                cmd.Parameters.AddWithValue("@email", newUser.Email);
                cmd.Parameters.AddWithValue("@noTlp", newUser.NoTlp);

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

        public int UpdateProfile(User newUser)
        {
            int result = 0;
            string query = @"UPDATE users SET nama=@nama, password=@password, email=@email, no_tlp=@noTlp WHERE id=@id";

            using (MySqlCommand cmd = new MySqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@nama", newUser.Nama);
                cmd.Parameters.AddWithValue("@password", newUser.Password);
                cmd.Parameters.AddWithValue("@email", newUser.Email);
                cmd.Parameters.AddWithValue("@noTlp", newUser.NoTlp);
                cmd.Parameters.AddWithValue("@id", newUser.Id);

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
