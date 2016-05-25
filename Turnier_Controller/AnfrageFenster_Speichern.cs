using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Turnierplan_Software;
using Turnierklassen;

namespace Turnier_Controller
{
    class AnfrageFenster_Speichern
    {
        private AnfrageFenster _Fenster;
        public AnfrageFenster_Speichern(EventHandler anfrage_beantwortet)
        {
            _Fenster = new AnfrageFenster("Einige Änderungen wurden noch nicht gespeichert!\nJetzt Speichern?");
            _Fenster.Bestaetigung_gegeben += On_Bestaetigung_gegeben;
            _Fenster.Bestaetigung_nicht_gegeben += On_Bestaetigung_nicht_gegeben;
            _Fenster.Schliessen += anfrage_beantwortet;
            _Fenster.Show();
        }

        private void On_Bestaetigung_gegeben(object sender, EventArgs e)
        {
            Datei_Interakteur.Save(); 
            _Fenster.Close();
        }

        private void On_Bestaetigung_nicht_gegeben(object sender, EventArgs e)
        {
            Datei_Interakteur.Delete_Temp();
            _Fenster.Close();
        }
    }
}
