using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _Darstellunsbereich.Children.Add(_Turnierfester);
        }

        private void Set_Event_Listeners()
        {
            _Turnierfester.Mannschaft_Hinzufuegen += On_Mannschaft_hinzufuegen;
        }

        private void On_Mannschaft_hinzufuegen(object sender, EventArgs e)
        {
            new DialogFensterMannschaft_Interakteur(_Turnier);
        }
    }
}
