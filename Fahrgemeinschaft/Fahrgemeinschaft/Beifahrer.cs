using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrgemeinschaft
{
    internal class Beifahrer
    {
        //Properties for Creating passenger
        public bool Fahrers { get; set; }
        public string WohnOrt { get; set; }
        public string ZielOrt { get; set; }
        public DateTime Abfahrtzeit { get; set; }

        //Construktor for creating passenger
        public Beifahrer(DateTime abfahrtzeit,bool fahrers, string wohnOrt, string zielOrt)
        {
            Abfahrtzeit = abfahrtzeit;
            Fahrers = fahrers;
            WohnOrt = wohnOrt;
            ZielOrt = zielOrt;

        }
    }
}
