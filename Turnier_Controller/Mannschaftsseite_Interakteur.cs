using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnierplan_Software;
using Turnierklassen;
using System.Windows.Controls;
using System.Reflection;
using System.ComponentModel;

namespace Turnier_Controller
{
    class Mannschaftsseite_Interakteur
    {
        private Mannschaftsseite _Mannschaftsseite;
        private Mannschaft _Mannschaft;
        private Grid _Darstellungsbereich;

        public Mannschaftsseite_Interakteur(Grid darstellungsbereich, Mannschaft mannschaft)
        {
            _Mannschaftsseite = new Mannschaftsseite();
            _Darstellungsbereich = darstellungsbereich;
            _Mannschaft = mannschaft;
            Comboboxen_fuellen();
            Mannschaftsdetails_eintragen();
            Hooks_einbinden();
            _Darstellungsbereich.Children.Add(_Mannschaftsseite);
        }

        private void Hooks_einbinden()
        {
            _Mannschaftsseite.Altersgruppe.SelectionChanged += Altersgruppe_festlegen;
            _Mannschaftsseite.Geschlecht.SelectionChanged += Geschlecht_festlegen;
            _Mannschaftsseite.Aus_Bayern.Checked += Aus_Bayern_Checked;
            _Mannschaftsseite.Aus_Bayern.Unchecked += Aus_Bayern_Unchecked;
            _Mannschaftsseite.Ist_Spaetstarter.Checked += Ist_Spaetstarter_Checked;
            _Mannschaftsseite.Ist_Spaetstarter.Unchecked += Ist_Spaetstarter_Unchecked;
        }

        private void Ist_Spaetstarter_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            _Mannschaft.Ist_Spaetstarter = false;
            Datei_Interakteur.Save_Temp();
        }

        private void Ist_Spaetstarter_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            _Mannschaft.Ist_Spaetstarter = true;
            Datei_Interakteur.Save_Temp();
        }

        private void Aus_Bayern_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            _Mannschaft.Ist_aus_Bayern = false;
            Datei_Interakteur.Save_Temp();
        }

        private void Aus_Bayern_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            _Mannschaft.Ist_aus_Bayern = true;
            Datei_Interakteur.Save_Temp();
        }

        private void Geschlecht_festlegen(object sender, SelectionChangedEventArgs e)
        {
            if (_Mannschaftsseite.Geschlecht.SelectedItem != null)
            {
                _Mannschaft.Geschlecht = (Geschlecht)_Mannschaftsseite.Geschlecht.SelectedItem;
                Datei_Interakteur.Save_Temp();
            }
        }

        private void Altersgruppe_festlegen(object sender, SelectionChangedEventArgs e)
        {
            if(_Mannschaftsseite.Altersgruppe.SelectedItem != null)
            {
                _Mannschaft.Altersgruppe = (Altersgruppe)_Mannschaftsseite.Altersgruppe.SelectedItem;
                Datei_Interakteur.Save_Temp();
            }
        }

        private void Mannschaftsdetails_eintragen()
        {
            _Mannschaftsseite.Mannschaftsname.Content = _Mannschaft.Name;
            _Mannschaftsseite.Aus_Bayern.IsChecked = _Mannschaft.Ist_aus_Bayern;
            _Mannschaftsseite.Ist_Spaetstarter.IsChecked = _Mannschaft.Ist_Spaetstarter;
            _Mannschaftsseite.Altersgruppe.SelectedIndex = _Mannschaftsseite.Altersgruppe.Items.IndexOf(_Mannschaft.Altersgruppe);
            _Mannschaftsseite.Geschlecht.SelectedIndex = _Mannschaftsseite.Geschlecht.Items.IndexOf(_Mannschaft.Geschlecht);
        }

        private void Comboboxen_fuellen()
        {
            foreach (Altersgruppe altersgruppe in Enum.GetValues(typeof(Altersgruppe)))
            {
                //Code zum Maskieren der Enum-Typen
                //Über die Description kann der Bindestrich bei den Jugenden eingefügt werden
                //Die Rückauflösung der Description auf den Enum-Typen ist aufwändig, daher erstmal zurückgestellt
                /*if (altersgruppe == Mannschaft.Altersgruppe.DJugend)
                {
                    MemberInfo[] info = typeof(Mannschaft.Altersgruppe).GetMember(altersgruppe.ToString());
                    object[] attrs = info[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    _Mannschaftsseite.Altersgruppe.Items.Add(((DescriptionAttribute)attrs[0]).Description);
                }*/
                _Mannschaftsseite.Altersgruppe.Items.Add(altersgruppe);
                
            }
            foreach (Geschlecht geschlecht in Enum.GetValues(typeof(Geschlecht)))
            {
                _Mannschaftsseite.Geschlecht.Items.Add(geschlecht);
            }
        }
    }
}
