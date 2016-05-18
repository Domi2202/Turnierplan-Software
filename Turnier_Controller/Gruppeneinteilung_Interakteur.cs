using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnierplan_Software;
using Turnierklassen;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Turnier_Controller
{
    class Gruppeneinteilung_Interakteur
    {
        private Gruppeneinteilung _Gruppenfenster;
        private Grid _Darstellungsbereich;
        private Turnier _Turnier;
        private List<Gruppenbox_Interakteur> _Gruppenboxen;

        public Gruppeneinteilung_Interakteur(Grid darstellungsbereich, Turnier turnier)
        {
            _Gruppenfenster = new Gruppeneinteilung();
            _Turnier = turnier;
            _Darstellungsbereich = darstellungsbereich;
            _Gruppenfenster.Label_Turniername.Content = _Turnier.Name;
            Darstellungsbereich_vorbereiten();
            Ansicht_aktualisieren();
            SetEventListeners();
        }

        private void SetEventListeners()
        {
            _Gruppenfenster.IsVisibleChanged += Ansicht_aktualisieren;
            _Gruppenfenster.Anzahl_Gruppen.SelectionChanged += Gruppenzahl_setzen;
            _Gruppenfenster.Btn_Zuteilen += Alle_Gruppen_fuellen;
            _Gruppenfenster.Btn_Ausleeren += Alle_Gruppen_leeren;
            _Gruppenfenster.Gruppengrenzen_aktualisiert += Gruppenrahmen_ersetzen;
            _Gruppenfenster.Gruppengroessen_anpassen += Gruppengroessen_anpassen;
            _Gruppenfenster.Warnung_verstecken += Warnung_verstecken;
        }

        private void Darstellungsbereich_vorbereiten()
        {
            _Darstellungsbereich.Children.Add(_Gruppenfenster);
        }

        #region Ansicht

        private void Ansicht_aktualisieren()
        {
            Listen_bereinigen();
            Mannschaftspool_zusammenstellen();
            Gruppenrahmen_setzen();
            Gruppenauswahl_erzeugen();
            Gruppenboxen_erzeugen();
            Poolzaehler_erneuern();
            Gruppenboxen_platzieren();
            Spielanzahl_zeigen();
            Poolgroesse_abgleichen();
        }

        private void Ansicht_aktualisieren(object sender, DependencyPropertyChangedEventArgs e)
        {
            Ansicht_aktualisieren();
        }

        private void Listen_bereinigen()
        {
            _Gruppenfenster.Listbox_Pool.Items.Clear();
            _Gruppenfenster.Anzahl_Gruppen.Items.Clear();
            _Gruppenfenster.Grid_Gruppenboxen.Children.Clear();
        }

        private void Mannschaftspool_zusammenstellen()
        {
            foreach (Mannschaft mannschaft in _Turnier.Mannschaften)
            {
                _Gruppenfenster.Listbox_Pool.Items.Add(new Listenelement<Mannschaft>(mannschaft, mannschaft.Name));
            }
        }

        private void Poolzaehler_erneuern()
        {
            _Gruppenfenster.Label_Poolzahl.Content = _Gruppenfenster.Listbox_Pool.Items.Count + "/" + _Turnier.Mannschaften.Count;
        }

        private void Poolzaehler_erneuern(object sender, EventArgs e)
        {
            Poolzaehler_erneuern();
        }

        private void Gruppenauswahl_erzeugen()
        {
            foreach (int gruppenzahl in Gruppenvorschlaege_errechnen())
            {
                _Gruppenfenster.Anzahl_Gruppen.Items.Add(gruppenzahl);
            }
            _Gruppenfenster.Anzahl_Gruppen.SelectedItem = _Turnier.Gruppen.Count;
        }

        private void Gruppenboxen_erzeugen()
        {
            _Gruppenboxen = new List<Gruppenbox_Interakteur>();
            foreach (Gruppe gruppe in _Turnier.Gruppen)
            {
                Gruppenbox_Interakteur grup_int = new Gruppenbox_Interakteur(_Gruppenfenster.Grid_Gruppenboxen, gruppe, _Gruppenfenster.Listbox_Pool);
                _Gruppenboxen.Add(grup_int);
                grup_int.Teilnehmer_verschoben += Poolzaehler_erneuern;
            }
        }

        private void Gruppenboxen_platzieren()
        {
            int row = 0;
            int col = 0;
            foreach (Gruppenbox_Interakteur grup_int in _Gruppenboxen)
            {
                grup_int.Box_platzieren(col, row);
                if (col == 1)
                {
                    col = 0;
                    row++;
                }
                else col = 1;
            }
        }

        private void Gruppenrahmen_setzen()
        {
            _Gruppenfenster.Gruppen_von.Text = Convert.ToString(_Turnier.Gruppen_von_Teilnehmerzahl);
            _Gruppenfenster.Gruppen_bis.Text = Convert.ToString(_Turnier.Gruppen_bis_Teilnehmerzahl);
        }

        private void Spielanzahl_zeigen()
        {
            _Gruppenfenster.Label_Zahl.Content = Spielanzahl_berechnen();
        }

        private int Spielanzahl_berechnen()
        {
            int spiele = 0;
            foreach (Gruppe gruppe in _Turnier.Gruppen)
            {
                int n = gruppe.Anzahl_Teilnehmer - 1;
                while (n > 0)
                {
                    spiele += n;
                    n--;
                }
            }
            return spiele;
        }

        #endregion Ansicht
        
        private void Poolgroesse_abgleichen()
        {
            if (_Turnier.Gruppen.Count != 0)
            {
                int gruppenteilnehmer = 0;
                foreach (Gruppe gruppe in _Turnier.Gruppen)
                {
                    gruppenteilnehmer += gruppe.Anzahl_Teilnehmer;
                }
                if (gruppenteilnehmer != _Turnier.Mannschaften.Count)
                {
                    _Gruppenfenster.Warnung_teilnehmer_entfernt.Visibility = Visibility.Visible;
                }
                else
                {
                    _Gruppenfenster.Warnung_teilnehmer_entfernt.Visibility = Visibility.Hidden;
                }
            }
        }     

        private List<int> Gruppenvorschlaege_errechnen()
        {
            List<int> gruppenzahlen = new List<int>();
            int teilnehmerzahl = _Turnier.Mannschaften.Count;
            int min = (int)Math.Ceiling((double)teilnehmerzahl / _Turnier.Gruppen_bis_Teilnehmerzahl);
            int max = teilnehmerzahl / _Turnier.Gruppen_von_Teilnehmerzahl;
            if (min != max && min < max)
            {
                for (int i = min; i <= max; i++)
                {
                    gruppenzahlen.Add(i);
                }
            }
            else gruppenzahlen.Add(min);
            return gruppenzahlen;
        }

        private void Gruppenzahl_setzen(object sender, SelectionChangedEventArgs e)
        {
            if (_Gruppenfenster.Anzahl_Gruppen.SelectedItem != null)
            {
                if (_Turnier.Gruppen.Count != (int)_Gruppenfenster.Anzahl_Gruppen.SelectedItem)
                {
                    _Turnier.Gruppen.Clear();
                    for (int i = 1; i <= (int)_Gruppenfenster.Anzahl_Gruppen.SelectedItem; i++)
                    {
                        Gruppe neue_gruppe = new Gruppe("Gruppe " + i);
                        _Turnier.Gruppen.Add(neue_gruppe);
                    }
                    Gruppenteilnehmerzahlen_setzen();
                    Ansicht_aktualisieren();
                    Datei_Interakteur.Save_Temp();
                }
            }
        }

        private void Gruppenteilnehmerzahlen_setzen()
        {
            int pool = _Turnier.Mannschaften.Count;
            int gruppen_anz = _Turnier.Gruppen.Count;
            for (int i = 0; i < gruppen_anz; i++)
            {
                int n = (int)Math.Ceiling((double)pool / (gruppen_anz - i));
                _Turnier.Gruppen.ElementAt(i).Anzahl_Teilnehmer = n;
                pool -= n;
            }
        }

        private void Alle_Gruppen_fuellen(object sender, EventArgs e)
        {
            foreach (Gruppenbox_Interakteur grup_int in _Gruppenboxen)
            {
                grup_int.Alle_Mannschaften_hinzufuegen(this, null);
            }
        }
            

        private void Alle_Gruppen_leeren(object sender, EventArgs e)
        {
            foreach (Gruppenbox_Interakteur grup_int in _Gruppenboxen)
            {
                grup_int.Alle_Mannschaften_entfernen(this, null);
            }
        }

        private void Gruppenrahmen_ersetzen(object sender, EventArgs e)
        {
            if (_Gruppenfenster.Gruppen_von.Text == string.Empty || _Gruppenfenster.Gruppen_bis.Text == string.Empty)
            {
                return;
            }
            int min = Convert.ToInt16(_Gruppenfenster.Gruppen_von.Text);
            int max = Convert.ToInt16(_Gruppenfenster.Gruppen_bis.Text);
            if (min > max)
            {
                Ansicht_aktualisieren();
                new FehlerFenster("Die minimale Anzahl an Mannschaften pro Gruppe kann nicht größer sein, als die maximale Anzahl an Mannschaften pro Gruppe!").Show();
            }
            else if (min <= 0 || max <= 0)
            {
                Ansicht_aktualisieren();
                new FehlerFenster("Minimum und maximum der Gruppenteilnehmer müssen größer als null sein!").Show();
            }
            else
            {
                _Turnier.Gruppen_von_Teilnehmerzahl = min;
                _Turnier.Gruppen_bis_Teilnehmerzahl = max;
                Datei_Interakteur.Save_Temp();
                Ansicht_aktualisieren();
            }
        }

        private void Gruppengroessen_anpassen(object sender, EventArgs e)
        {
            foreach (Gruppenbox_Interakteur grup_int in _Gruppenboxen)
            {
                if (grup_int.Teilnehmer_fehlt)
                {
                    grup_int.Teilnehmerzahl -= grup_int.Fehlende_Teilnehmerzahl;
                }
            }
            Ansicht_aktualisieren();
            Warnung_verstecken();
        }

        private void Warnung_verstecken()
        {
            _Gruppenfenster.Warnung_teilnehmer_entfernt.Visibility = Visibility.Hidden;
        }

        private void Warnung_verstecken(object sender, EventArgs e)
        {
            Warnung_verstecken();
        }

    }
}
