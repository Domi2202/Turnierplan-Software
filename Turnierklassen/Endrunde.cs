using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Endrunde
    {
        public int anzahl_teilnehmer;
        //public List<Paarung> paarungen;
        public bool ist_trostrunde;
        public int modus;
        public List<Runde> runden;
    }

    public class Runde
    {
        //public int id;
        //public int anzahl_paarungen;
        public List<Paarung> paarungen;
    }
}
