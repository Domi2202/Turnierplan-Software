using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Mannschaft
    {
        public string name;
        public bool aus_bayern;
        public bool ist_spaetstarter;
        //public Gesamtergebnis gruppenergebnis;
        public List<Paarung> paarungen;
        public enum Geschlecht {Männlich, Weiblich};
        public enum Altersgruppe { Minis, DJugend, CJugend, BJugend, AJugend, Erwachsene };

    }
}
