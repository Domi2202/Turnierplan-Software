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
        }

        private void Darstellungsbereich_vorbereiten()
        {
            //_Darstellunsbereich.ColumnDefinitions.Add(new ColumnDefinition());
            _Darstellunsbereich.Children.Add(_Turnierfester);
            //Turnierfenster t2 = new Turnierfenster();
            // _Darstellunsbereich.Children.Add(t2);
            Grid.SetColumn(_Turnierfester, 0);
            //Grid.SetColumn(t2, 1);
        }

        private void On_Mannschaft_hinzufuegen(object sender, EventArgs e)
        {
            new DialogFensterMannschaft_Interakteur(On_Mannschaft_angelegt, _Turnier);
        }

        private void Ansicht_aktualisieren()
        {
            _Turnierfester.Mannschaften.Items.Clear();
            foreach (Mannschaft mannschaft in _Turnier.Mannschaften)
            {
                _Turnierfester.Mannschaften.Items.Add(new Listenelement<Mannschaft>(mannschaft, mannschaft.Name));
            }
        }

        private void On_Mannschaft_angelegt(object sender, EventArgs e)
        {
            Ansicht_aktualisieren();
        }
    }
}
