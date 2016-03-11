using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    class Turnier
    {
        public string name;
        public double spieldauer_minuten;
        public double halbzeitpause_minuten;
        public List<Mannschaft> mannschaften;
        public List<Gruppe> gruppen;
        public Endrunde endrunde;
        public Endrunde trostrunde;
    }
}
