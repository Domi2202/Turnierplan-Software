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
            Ansicht_Laden();
            Informationen_Laden();
            SetEventListeners();
        }

        private void Ansicht_Laden()
        {
            _Darstellungsbereich.Children.Add(_Fenster);
        }

        private void Informationen_Laden()
        {
            _Fenster.DataContext = _Turnier.Endrunde;
            _Fenster.label_Turniername.DataContext = _Turnier;
        }

        private void SetEventListeners()
        {
            _Fenster.AddParticipationRule += AddParticipationRule;
            _Fenster.DeleteParticipationRule += DeleteParticipationRule;
            _Fenster.TeilnahmeregelAnzeigen += TeilnahmeregelAnzeigen;
        }

        #region EventHandler

        private void DeleteParticipationRule(object sender, EventArgs e)
        {
            if (_Fenster.listbox_Teilnehmer.SelectedItem != null)
            {
                _Turnier.Endrunde.DeleteParticipationRule(_Fenster.listbox_Teilnehmer.SelectedIndex);
            }
        }

        private void AddParticipationRule(object sender, EventArgs e)
        {
            new Teilnahmeregel_Interakteur(_Turnier);
        }

        private void TeilnahmeregelAnzeigen(object sender, EventArgs e)
        {
            if (_Fenster.listbox_Teilnehmer.SelectedItem != null)
            {
                ParticipationRule regel = _Turnier.Endrunde.Teilnahmeregeln.ElementAt(_Fenster.listbox_Teilnehmer.SelectedIndex);
                string info = string.Empty;
                foreach (ParticipationRule.Kandidat kandidat in regel.CriteriaList)
                {
                    info += kandidat.Rank + ". Gruppe " + kandidat.Group + "\noder\n";
                }
                info = info.TrimEnd('r', 'e', 'd', 'o', '\n');
                new FehlerFenster(info).Show();
            }          
        }


        #endregion
    }
}
