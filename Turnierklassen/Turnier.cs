using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Turnier
    {
        private Altersgruppe _altersgruppe;
        private Geschlecht _geschlecht;
        public string Name { get; set; }
        public double Spieldauer_Minuten { get; set; }
        public double Halbzeitpause_Minuten { get; set; }
        public List<Mannschaft> Mannschaften { get; set; }
        public List<Gruppe> Gruppen { get; set; }
        public Endrunde Endrunde { get; set; }
        public Trostrunde Trostrunde { get; set; }
        public int Gruppen_von_Teilnehmerzahl { get; set; }
        public int Gruppen_bis_Teilnehmerzahl { get; set; }


        public Geschlecht Geschlecht {
            get { return _geschlecht; }
            set
            {
                _geschlecht = value;
                    Datei_Interakteur.Save_Temp();

            }
        }
        public Altersgruppe Altersgruppe 
        {
            get { return _altersgruppe; }
            set
            {
                _altersgruppe = value;
                Datei_Interakteur.Save_Temp();
            }
        }


        public Turnier()
        {
            Mannschaften = new List<Mannschaft>();
            Gruppen = new List<Gruppe>();
            Trostrunde = new Trostrunde();
            Endrunde = new Endrunde();
            Altersgruppe = Turnierklassen.Altersgruppe.Erwachsene;
            Gruppen_von_Teilnehmerzahl = 3;
            Gruppen_bis_Teilnehmerzahl = 5;
        }
   

        
    }
}
