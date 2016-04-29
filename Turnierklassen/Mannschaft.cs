using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Altersgruppe Altersgruppe { get; set; }
        public Geschlecht Geschlecht { get; set; }
    }
    public enum Geschlecht { Männlich, Weiblich };
    public enum Altersgruppe { Erwachsene, AJugend, BJugend, CJugend, DJugend, Minis /*[Description("D-jugend")]*/ };
}
