using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Paarung
    {
        public Mannschaft Mannschaft_A { get; set; }
        public Mannschaft Mannschaft_B { get; set; }
        public List<Halbzeitergebnis> Halbzeitergebnisse { get; set; }
    }

    public class Halbzeitergebnis
    {
        public int Tore_A { get; set; }
        public int Tore_B { get; set; }
    }
}
