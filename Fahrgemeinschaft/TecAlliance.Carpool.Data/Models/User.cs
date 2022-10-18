using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecAlliance.Carpool.Data.Models
{
    public class User
    {
        public string? Name { get; set; }
        public string? Nachname { get; set; }
        public string? Anmeldename { get; set; }
        public string? Passwort { get; set; }
        public string? Gender { get; set; }
        public int Alter { get; set; }
    }
}
