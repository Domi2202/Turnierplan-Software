using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Turnierplan_Software;
using Turnierklassen;
using System.Windows.Controls;

namespace Turnier_Controller
{
    class Turnierfenster_Interakteur
    {
        private Turnierfenster _Turnierfester;
        private Grid _Darstellunsbereich;
        private Turnier _Turnier;

        public Turnierfenster_Interakteur(Grid darstellungsbereich, Turnier turnier)
        {
            _Turnierfester = new Turnierfenster();
            _Turnier = turnier;
            _Darstellunsbereich = darstellungsbereich;
            _Turnierfester.Turniername.Content = _Turnier.Name;
            Set_Event_Listeners();
            Ansicht_aktualisieren();
            Darstellungsbereich_vorbereiten();
        }

        private void Set_Event_Listeners()
        {
            _Turnierfester.Mannschaft_Hinzufuegen += On_Mannschaft_hinzufuegen;
            _Turnierfester.Mannschaft_Loeschen += Mannschaft_loeschen;
            _Turnierfester.Mannschaften.SelectionChanged += Mannschaftsdetails_zeigen;
        }

        private void Mannschaft_loeschen(object sender, EventArgs e)
        {
            Listenelement<Mannschaft> zu_loeschen = (Listenelement<Mannschaft>)_Turnierfester.Mannschaften.SelectedItem;
            if (zu_loeschen != null)
            {
                _Turnier.Mannschaften.Remove(zu_loeschen.Details);
                Datei_Interakteur.Save_Temp();
                Ansicht_aktualisieren();
            }
        }

        private void Mannschaftsdetails_zeigen(object sender, SelectionChangedEventArgs e)
        {
            if (_Turnierfester.Mannschaften.SelectedItem != null)
            {
                _Turnierfester.Bereich_fuer_Mannschaftsdetails.Children.Clear();
                Listenelement<Mannschaft> angeklickt = _Turnierfester.Mannschaften.SelectedItem as Listenelement<Mannschaft>;
                new Mannschaftsseite_Interakteur(_Turnierfester.Bereich_fuer_Mannschaftsdetails, angeklickt.Details);
            }
        }

        private void Darstellungsbereich_vorbereiten()
        {
            _Darstellunsbereich.Children.Add(_Turnierfester);
        }

        private void On_Mannschaft_hinzufuegen(object sender, EventArgs e)
        {
            new DialogFensterMannschaft_Interakteur(Ansicht_aktualisieren, _Turnier);
        }

        private void Ansicht_aktualisieren()
        {
            _Turnierfester.Mannschaften.Items.Clear();
            _Turnierfester.Bereich_fuer_Mannschaftsdetails.Children.Clear();
            foreach (Mannschaft mannschaft in _Turnier.Mannschaften)
            {
                _Turnierfester.Mannschaften.Items.Add(new Listenelement<Mannschaft>(mannschaft, mannschaft.Name));
            }
        }

        private void Ansicht_aktualisieren(object sender, EventArgs e)
        {
            Ansicht_aktualisieren();
            SelectLastItem();
        }

        private void SelectLastItem()
        {
            _Turnierfester.Mannschaften.SelectedItem = _Turnierfester.Mannschaften.Items.GetItemAt(_Turnierfester.Mannschaften.Items.Count - 1);
        }
    }
}
