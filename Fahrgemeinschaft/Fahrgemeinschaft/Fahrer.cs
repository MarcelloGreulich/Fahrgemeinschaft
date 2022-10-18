using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tecalliance.Carpool.Models
{
    internal class Fahrer
    {
        //Properties for Creating driver
        public string AutoBezeichnung { get; set; }
        public int FreeSeat { get; set; }
        public bool Fahrers { get; set; }
        public string WohnOrt { get; set; }
        public string ZielOrt { get; set; }
        public DateTime Abfahrtzeit { get; set; }
        //Construktor for creating driver
        public Fahrer(DateTime abfahrtzeit, bool fahrers, string wohnOrt, string zielOrt, string autoBezeichnung, int freeSeat)
        {
            Abfahrtzeit = abfahrtzeit;
            Fahrers = fahrers;
            WohnOrt = wohnOrt;
            ZielOrt = zielOrt;
            AutoBezeichnung = autoBezeichnung;
            FreeSeat = freeSeat;
        }
    }
}
