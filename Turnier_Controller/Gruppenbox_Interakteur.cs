using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnierplan_Software;
using Turnierklassen;
using System.Windows.Controls;
using System.Windows;
using System.Diagnostics;
using System.Windows.Media;

namespace Turnier_Controller
{
    class Gruppenbox_Interakteur
    {
        private Gruppenbox _Gruppenbox;
        private Grid _Darstellungsbereich;
        private Gruppe _Gruppe;
        private ListBox _Pool;
        private List<Mannschaft> _Fehlende_Teilnehmer;

        public int Teilnehmerzahl
        {
            get { return _Gruppe.Anzahl_Teilnehmer; }
            set
            {
                _Gruppe.Anzahl_Teilnehmer = value;
                if(Gruppenlimit_veraendert != null)
                {
                    Gruppenlimit_veraendert(this, null);
                }
            }
        }

        public int Fehlende_Teilnehmerzahl
        {
            get { return _Fehlende_Teilnehmer.Count; }
        }
        public bool Teilnehmer_fehlt { get; private set; }
        public EventHandler Teilnehmer_verschoben { get; set; }
        public EventHandler Gruppenlimit_veraendert { get; set; }

        public Gruppenbox_Interakteur(Grid darstellungsbereich, Gruppe gruppe, ListBox pool)
        {
            Teilnehmer_fehlt = false;
            _Gruppenbox = new Gruppenbox();
            _Fehlende_Teilnehmer = new List<Mannschaft>();
            _Gruppe = gruppe;
            _Pool = pool;
            _Darstellungsbereich = darstellungsbereich;
            Komplette_Ansicht_laden();
            Set_Event_Listeners();
        }

        private void Set_Event_Listeners()
        {
            _Gruppenbox.Gruppenbox_Hinzufügen += Mannschaft_Hinzufuegen;
            _Gruppenbox.Gruppenbox_Raus += Mannschaft_entfernen;
            _Gruppenbox.Gruppenbox_Leeren += Alle_Mannschaften_entfernen;
            _Gruppenbox.Gruppenbox_Füllen += Alle_Mannschaften_hinzufuegen;
            Teilnehmer_verschoben += Teilnehmerzahl_setzen;
        }

        private void Komplette_Ansicht_laden()
        {
            Gruppeninformation_anzeigen();
            Alle_Mannschaften_aus_Pool_holen();
            Fehlende_Teilnehmer_entfernen();
            Teilnehmerliste_erneuern();
            Teilnehmerzahl_anzeigen();
        }

        private void Gruppeninformation_anzeigen()
        {
            _Gruppenbox.Gruppenname.Content = _Gruppe.Name;
        }

        private void Teilnehmerzahl_anzeigen()
        {
            _Gruppenbox.Anzahl.Foreground = Brushes.Black;
            if (_Gruppe.Teilnehmer.Count > _Gruppe.Anzahl_Teilnehmer)
            {
                _Gruppenbox.Anzahl.Foreground = Brushes.Red;
            }
            string max_teilnehmer = Convert.ToString(_Gruppe.Anzahl_Teilnehmer);
            string akt_teilnehmer = Convert.ToString(_Gruppe.Teilnehmer.Count);
            _Gruppenbox.Anzahl.Content = akt_teilnehmer + "/" + max_teilnehmer;
            
        }

        private void Teilnehmerzahl_setzen(object sender, EventArgs e)
        {
            Teilnehmerzahl_anzeigen();
        }

        private void Teilnehmerliste_erneuern()
        {
            _Gruppenbox.Mannschaften.Items.Clear();
            foreach (Mannschaft mannschaft in _Gruppe.Teilnehmer)
            {
                _Gruppenbox.Mannschaften.Items.Add(new Listenelement<Mannschaft>(mannschaft, mannschaft.Name));
            }
        }

        private void Alle_Mannschaften_aus_Pool_holen()
        {
            foreach (Mannschaft mannschaft in _Gruppe.Teilnehmer)
            {
                Mannschaft_aus_Pool_holen(mannschaft);
            }
        }

        private void Mannschaft_aus_Pool_holen(Mannschaft mannschaft)
        {
            try
            {
                _Pool.Items.Remove(Finde_in_Pool(mannschaft));
            }
            catch (Exception e)
            {
                Teilnehmer_fehlt = true;
                _Fehlende_Teilnehmer.Add(mannschaft);
            }
        }

        private object Finde_in_Pool(Mannschaft mannschaft)
        {
            foreach (var item in _Pool.Items) 
            {
                Listenelement<Mannschaft> x = item as Listenelement<Mannschaft>;
                if (x.Details.Name == mannschaft.Name)
                {
                    return item;
                }
            }
            throw new Exception("Die Mannschaft ist nicht im Pool");
        }

        private void Fehlende_Teilnehmer_entfernen()
        {
            foreach (Mannschaft teilnehmer in _Fehlende_Teilnehmer)
            {
                _Gruppe.Teilnehmer.Remove(teilnehmer);
            }
        }

        public void Box_platzieren(int col, int row)
        {
            _Darstellungsbereich.Children.Add(_Gruppenbox);
            Grid.SetColumn(_Gruppenbox, col);
            Grid.SetRow(_Gruppenbox, row);
        }

        private void Mannschaft_Hinzufuegen(Mannschaft mannschaft)
        {
            if (mannschaft != null && _Gruppe.Teilnehmer.Count < _Gruppe.Anzahl_Teilnehmer)
            {
                _Gruppe.Teilnehmer.Add(mannschaft);
                Mannschaft_aus_Pool_holen(mannschaft);
                if (Teilnehmer_verschoben != null)
                {
                    Teilnehmer_verschoben(this, null);
                }
            }
        }

        private void Mannschaft_Hinzufuegen(object sender, EventArgs e)
        {
            Listenelement<Mannschaft> mannschaft = _Pool.SelectedItem as Listenelement<Mannschaft>;
            if (mannschaft != null)
            { 
                Mannschaft_Hinzufuegen(mannschaft.Details);
                Teilnehmerliste_erneuern();
                Datei_Interakteur.Save_Temp();
            }
        }

        internal void Alle_Mannschaften_hinzufuegen(object sender, EventArgs e)
        {
            int teilnehmer = _Gruppe.Teilnehmer.Count;
            int max_teilnehmer = _Gruppe.Anzahl_Teilnehmer;
            Random ran = new Random();
            for (int i = teilnehmer; i < max_teilnehmer; i++)
            {
                if (_Pool.Items.Count == 0)
                {
                    new FehlerFenster("Es sind nicht genügend Mannschaften im Pool um "+ _Gruppe.Name + " zu füllen!").Show();
                    break;
                }
                else
                {
                    int next = ran.Next(0, _Pool.Items.Count - 1);
                    Listenelement<Mannschaft> mannschaft = _Pool.Items.GetItemAt(next) as Listenelement<Mannschaft>;
                    Mannschaft_Hinzufuegen(mannschaft.Details);
                }
            }
            Teilnehmerliste_erneuern();
            Datei_Interakteur.Save_Temp();
        }

        private void Mannschaft_entfernen(Mannschaft mannschaft)
        {
            if (mannschaft != null)
            {
                _Gruppe.Teilnehmer.Remove(mannschaft);
                _Pool.Items.Add(new Listenelement<Mannschaft>(mannschaft, mannschaft.Name));
                if (Teilnehmer_verschoben != null)
                {
                    Teilnehmer_verschoben(this, null);
                }
            }
        }

        private void Mannschaft_entfernen(object sender, EventArgs e)
        {
            Listenelement<Mannschaft> mannschaft = _Gruppenbox.Mannschaften.SelectedItem as Listenelement<Mannschaft>;
            if (mannschaft != null)
            {
                Mannschaft_entfernen(mannschaft.Details);
                Teilnehmerliste_erneuern();
                Datei_Interakteur.Save_Temp();
            }
        }

        internal void Alle_Mannschaften_entfernen(object sender, EventArgs e)
        {
            foreach (var item in _Gruppenbox.Mannschaften.Items)
            {
                Listenelement<Mannschaft> list_mannschaft = item as Listenelement<Mannschaft>;
                Mannschaft_entfernen(list_mannschaft.Details);
            }
            Teilnehmerliste_erneuern();
            Datei_Interakteur.Save_Temp();
        }

        internal void Gruppengroesse_Auswahl_erstellen(int min, int max)
        {
            for (int i = min; i <= max; i++)
            {
                Button btn = new Button();
                btn.Content = Convert.ToString(i);
                btn.Click += Gruppengroesse_aendern;
                _Gruppenbox.Gruppengroesse_auswahl.Children.Add(btn);
            }
        }

        private void Gruppengroesse_aendern(object sender, RoutedEventArgs e)
        {
            Button clicked = sender as Button;
            int neue_groesse = Convert.ToInt16(clicked.Content);
            Teilnehmerzahl = neue_groesse;
            Teilnehmerzahl_anzeigen();
            Datei_Interakteur.Save_Temp();
        }
    }
}
