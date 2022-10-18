using System;

namespace Tecalliance.Carpool.Models
{
    internal class Beifahrer
    {
        //Properties for Creating passenger
        public bool Fahrers { get; set; }
        public string WohnOrt { get; set; }
        public string ZielOrt { get; set; }
        public DateTime Abfahrtzeit { get; set; }

        //Construktor for creating passenger
        public Beifahrer(DateTime abfahrtzeit, bool fahrers, string wohnOrt, string zielOrt)
        {
            Abfahrtzeit = abfahrtzeit;
            Fahrers = fahrers;
            WohnOrt = wohnOrt;
            ZielOrt = zielOrt;

        }
    }
}
