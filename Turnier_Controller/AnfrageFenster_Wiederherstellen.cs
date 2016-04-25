using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Turnierplan_Software;

namespace Turnier_Controller
{
    public class AnfrageFenster_Wiederherstellen
    {
        private Application _Programm;
        private AnfrageFenster _Fenster;
        public AnfrageFenster_Wiederherstellen(EventHandler anfrage_beantwortet, Application programm)
        {
            _Fenster = new AnfrageFenster("Es wurde eine Wiederherstellungsdatei gefunden, sollen die Daten geladen werden?");
            _Fenster.Bestaetigung_gegeben += On_Bestaetigung_gegeben;
            _Fenster.Bestaetigung_nicht_gegeben += On_Bestaetigung_nicht_gegeben;
            _Fenster.Schliessen += anfrage_beantwortet;
            _Programm = programm;
            _Programm.Run(_Fenster);
        }

        private void On_Bestaetigung_gegeben(object sender, EventArgs e)
        {
            Datei_Interakteur.Wiederherstellungsdatei_laden();
            _Fenster.Close();
        }

        private void On_Bestaetigung_nicht_gegeben(object sender, EventArgs e)
        {
            Datei_Interakteur.Delete_Temp();
            _Fenster.Close();
        }
    }
}

