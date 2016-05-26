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

        public Gruppe() { }

        public Gruppe(string name)
        {
            Name = name;
            Teilnehmer = new List<Mannschaft>();
        }

        public Gruppe(string name, int teilnehmer)
        {
            Name = name;
            Teilnehmer = new List<Mannschaft>();
            Anzahl_Teilnehmer = teilnehmer;
        }

        public int AnzahlSpieleBerechnen()
        {
            int spiele = 0;
            for (int i = Anzahl_Teilnehmer - 1; i > 0; i --)
            {
                spiele += i;
            }
            return spiele;
        }
    }
}
