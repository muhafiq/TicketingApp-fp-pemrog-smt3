using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp.Models.Entity
{
    public class Transaksi
    {
        public string Id { get; set; }
        public Event TicketDibeli { get; set; }
        public Stage StageDipilih { get; set; }
        public User UserPembeli { get; set; }
        public int Bayar { get; set; }
    }
}
