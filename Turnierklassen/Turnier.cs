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
        public TimeSpan Halbzeitdauer;
        public TimeSpan Pausendauer;


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
            Halbzeitdauer = new TimeSpan(0, 0, 0);
            Pausendauer = new TimeSpan(0, 0, 0);

            Gruppen_von_Teilnehmerzahl = 3;
            Gruppen_bis_Teilnehmerzahl = 5;
        }


        public void HalbzeitMinutenSetzen(int minuten)
        {
            int sek_akt = Halbzeitdauer.Seconds;
            Halbzeitdauer = new TimeSpan(0, minuten, sek_akt);
            Datei_Interakteur.Save_Temp();
        }

        public void Halbzeitsekundensetzten(int sekunden)
        {
            int min_akt = Halbzeitdauer.Minutes;
            Halbzeitdauer = new TimeSpan(0, min_akt, sekunden);
            Datei_Interakteur.Save_Temp();
        }

        public void Pausensekundensetzten(int sekunden)
        {
            int min_akt = Pausendauer.Minutes;
            Pausendauer = new TimeSpan(0, min_akt, sekunden);
            Datei_Interakteur.Save_Temp();
        }

        public void Pausenminutensetzten(int minuten)
        {
            int sek_akt = Pausendauer.Seconds;
            Pausendauer = new TimeSpan(0, sek_akt, minuten);
            Datei_Interakteur.Save_Temp();
        }
    }
}
