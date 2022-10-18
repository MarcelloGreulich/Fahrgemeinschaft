using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tecalliance.Carpool.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Nachname { get; set; }
        public string Anmeldename { get; set; }
        public string Passwort { get; set; }
        public string Gender { get; set; }
        public int Alter { get; set; }
        
        public User(string name, string nachname, string anmeldename, string passwort, string gender, int alter)
        {
            Name = name;
            Nachname = nachname;
            Anmeldename = anmeldename;
            Passwort = passwort;
            Gender = gender;
            Alter = alter;
        }

    }
}
