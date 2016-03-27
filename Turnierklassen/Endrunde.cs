using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Endrunde
    {
        public int Anzahl_Teilnehmer { get; set; }
        //public List<Paarung> Paarungen { get; set; }
        public bool Ist_Trostrunde { get; set; }
        public int Modus { get; set; }
        public List<Runde> Runden { get; set; }
    }

    public class Runde
    {
        public int ID { get; set; }
        public int Anzahl_Paarungen { get; set; }
        public List<Paarung> Paarungen { get; set; }
    }
}
