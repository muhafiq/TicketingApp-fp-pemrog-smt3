using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.Models.Entity;
using TicketingApp.Models.Repository;
using TicketingApp.Models.Context;
using System.Windows.Forms;

namespace TicketingApp.Controllers
{
    class UserController
    {
        public UserRepository _repository;

        public void Login(User userToAuth)
        {
            User userFromDb = null;
            using (DbContext context = new DbContext()) 
            {
                _repository = new UserRepository(context);
                userFromDb = _repository.Login(userToAuth);

                // check apakah data ada
                if (userFromDb == null)
                {
                    // return user tidak ditemukan
                    return;
                }
                
                // auth
                if (userToAuth.Email == userFromDb.Email && userToAuth.Password == userFromDb.Password)
                {
                    // return home app view
                }
                else
                {
                    // return msgBox email / password salah
                }

            }

        }

        public void Logout()
        {
            // return login page
        }

    }
}
