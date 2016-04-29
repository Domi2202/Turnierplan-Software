using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Turnier
    {
        public string Name { get; set; }
        public double Spieldauer_Minuten { get; set; }
        public double Halbzeitpause_Minuten { get; set; }
        public List<Mannschaft> Mannschaften { get; set; }
        public List<Gruppe> Gruppen { get; set; }
        public Endrunde Endrunde { get; set; }
        public Endrunde Trostrunde { get; set; }

        public Turnier()
        {
            Mannschaften = new List<Mannschaft>();
            Gruppen = new List<Gruppe>();
        }
    }
}
