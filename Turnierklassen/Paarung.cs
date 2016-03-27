using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Paarung
    {
        public Mannschaft mannschaft_a;
        public Mannschaft mannschaft_b;
        public List<Halbzeitergebnis> halbzeitergebnisse;
    }

    public class Halbzeitergebnis
    {
        public int tore_a;
        public int tore_b;
    }
}
