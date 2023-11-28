using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp.Models.Entity
{
    public class Event
    {
        public int Id { get; set; }
        public string NamaEvent { get; set; }
        public string Jenis { get; set; }
        public string Tanggal { get; set; }
        public string Lokasi { get; set; }
    }
}
