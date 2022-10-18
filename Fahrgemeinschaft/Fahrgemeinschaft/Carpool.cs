using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecalliance.Carpool.Models
{
    public class Carpool
    {
        public string Name { get; set; }
        public string Nachname { get; set; }
        public string Anmeldename { get; set; }
        public string Gender { get; set; }
        public int Alter { get; set; }
        public string AutoBezeichnung { get; set; }
        public int FreeSeat { get; set; }
        public bool Fahrers { get; set; }
        public string WohnOrt { get; set; }
        public string ZielOrt { get; set; }
        public DateTime Abfahrtzeit { get; set; }

        public Carpool(string name, string nachname, string anmeldename, string gender, int alter, DateTime abfahrtzeit, bool fahrers, string wohnOrt, string zielOrt, string autoBezeichnung, int freeSeat)
        {
            Name = name;
            Nachname = nachname;
            Anmeldename = anmeldename;
            Gender = gender;
            Alter = alter;
            Abfahrtzeit = abfahrtzeit;
            Fahrers = fahrers;
            WohnOrt = wohnOrt;
            ZielOrt = zielOrt;
            AutoBezeichnung = autoBezeichnung;
            FreeSeat = freeSeat;
        }
    }
}
