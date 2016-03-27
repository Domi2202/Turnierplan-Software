using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Mannschaft
    {
        public string Name { get; set; }
        public bool Ist_aus_Bayern { get; set; }
        public bool Ist_Spaetstarter { get; set; }
        //public Gesamtergebnis Gruppenergebnis { get; set; }
        public List<Paarung> Paarungen { get; set; }
        public enum Geschlecht {Männlich, Weiblich};
        public enum Altersgruppe { Minis, DJugend, CJugend, BJugend, AJugend, Erwachsene };

    }
}
