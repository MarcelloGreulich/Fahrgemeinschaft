using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecAlliance.Carpool.Business.Models
{
    public class CarpoolDto
    {
        public string? AutoBezeichnung { get; set; }
        public int FreeSeat { get; set; }
        public bool Fahrers { get; set; }
        public string? WohnOrt { get; set; }
        public string? ZielOrt { get; set; }
        public DateTime Abfahrtzeit { get; set; }
    }
}
