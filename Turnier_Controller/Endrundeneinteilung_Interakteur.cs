using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnierplan_Software;
using Turnierklassen;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;

namespace Turnier_Controller
{
    class Endrundeneinteilung_Interakteur
    {
        private Turnier _Turnier;
        private Endrundeneinteilung _Fenster;
        private Grid _Darstellungsbereich;

        public Endrundeneinteilung_Interakteur(Grid darstellungsbereich, Turnier turnier)
        {
            _Turnier = turnier;
            _Darstellungsbereich = darstellungsbereich;
            _Fenster = new Endrundeneinteilung();
            _Fenster.DataContext = _Turnier.Endrunde;
            Ansicht_Laden();
            Informationen_Laden();
            EventHandler_setzen();
        }

        private void Ansicht_Laden()
        {
            _Darstellungsbereich.Children.Add(_Fenster);
            Modi_Auswahl_füllen();
        }

        private void Modi_Auswahl_füllen()
        {
            _Fenster.Modus_Auswahl.ItemsSource = Enum.GetValues(typeof(Modus)).Cast<Modus>();
        }

        private void Informationen_Laden()
        {
            _Fenster.Modus_Auswahl.SelectedIndex = _Fenster.Modus_Auswahl.Items.IndexOf(_Turnier.Endrunde.Modus);
            _Fenster.label_Turniername.Content = _Turnier.Name;
        }

        private void EventHandler_setzen()
        {
            _Fenster.Modus_Auswahl.SelectionChanged += Modus_setzen;
        }

        private void Modus_setzen(object sender, SelectionChangedEventArgs e)
        {
            if (_Fenster.Modus_Auswahl.SelectedItem != null)
            {
                Modus mod_neu = (Modus)_Fenster.Modus_Auswahl.SelectedItem;
                Modus mod_alt = _Turnier.Endrunde.Modus;
                if (mod_neu != mod_alt)
                {
                    _Turnier.Endrunde.Modus = mod_neu;
                    Datei_Interakteur.Save_Temp();
                }
            }
        }
    }
}
