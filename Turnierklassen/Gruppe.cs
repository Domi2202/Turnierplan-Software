using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    class Gruppe
    {
        public string name;
        public int anzahl_teilnehmer;
        public List<Mannschaft> teilnehmer;
        public List<Paarung> paarungen;
    }
}
