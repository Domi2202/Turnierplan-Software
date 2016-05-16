using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Gruppe
    {
        public string Name { get; set; }
        public int Anzahl_Teilnehmer { get; set; }
        public List<Mannschaft> Teilnehmer { get; set; }
        public List<Paarung> Paarungen { get; set; }

        public Gruppe(string name)
        {
            Name = name;
            Teilnehmer = new List<Mannschaft>();
        }
    }
}
