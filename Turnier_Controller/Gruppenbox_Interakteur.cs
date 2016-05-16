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

namespace Turnier_Controller
{
    class Gruppenbox_Interakteur
    {
        private Gruppenbox _Gruppenbox;
        private Grid _Darstellungsbereich;
        private Gruppe _Gruppe;
        private ListBox _Pool;

        public int Teilnehmerzahl { get; set; }

        public Gruppenbox_Interakteur(Grid darstellungsbereich, Gruppe gruppe, ListBox pool)
        {
            _Gruppenbox = new Gruppenbox();
            _Gruppe = gruppe;
            _Pool = pool;
            _Darstellungsbereich = darstellungsbereich;
            Ansicht_aktualisieren();
            Set_Event_Listeners();
        }

        private void Set_Event_Listeners()
        {
            _Gruppenbox.Gruppenbox_Hinzufügen += Mannschaft_Hinzufuegen;
            _Gruppenbox.Gruppenbox_Raus += Mannschaft_entfernen;
            _Gruppenbox.Gruppenbox_Leeren += Alle_Mannschaften_entfernen;
            _Gruppenbox.Gruppenbox_Füllen += Alle_Mannschaften_hinzufuegen;
        }

        private void Ansicht_aktualisieren()
        {
            _Gruppenbox.Mannschaften.Items.Clear();
            _Gruppenbox.Gruppenname.Content = _Gruppe.Name;
            _Gruppenbox.Anzahl.Content = Convert.ToString(_Gruppe.Anzahl_Teilnehmer);
            Alle_Mannschaften_aus_Pool_holen();
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
            _Gruppenbox.Mannschaften.Items.Add(new Listenelement<Mannschaft>(mannschaft, mannschaft.Name));
            try
            {
                _Pool.Items.Remove(Finde_in_Pool(mannschaft));
            }
            catch (Exception e) { }
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
            }
        }

        private void Mannschaft_Hinzufuegen(object sender, EventArgs e)
        {
            Listenelement<Mannschaft> mannschaft = _Pool.SelectedItem as Listenelement<Mannschaft>;
            if (mannschaft != null)
            { 
                Mannschaft_Hinzufuegen(mannschaft.Details);
                Ansicht_aktualisieren();
                Datei_Interakteur.Save_Temp();
            }
        }

        private void Alle_Mannschaften_hinzufuegen(object sender, EventArgs e)
        {
            int teilnehmer = _Gruppe.Teilnehmer.Count;
            int max_teilnehmer = _Gruppe.Anzahl_Teilnehmer;
            Random ran = new Random();
            for (int i = teilnehmer; i < max_teilnehmer; i++)
            {
                int next = ran.Next(0, _Pool.Items.Count - 1);
                Listenelement<Mannschaft> mannschaft = _Pool.Items.GetItemAt(next) as Listenelement<Mannschaft>;
                Mannschaft_Hinzufuegen(mannschaft.Details);
                Mannschaft_aus_Pool_holen(mannschaft.Details);
            }
            Ansicht_aktualisieren();
            Datei_Interakteur.Save_Temp();
        }

        private void Mannschaft_entfernen(Mannschaft mannschaft)
        {
            if (mannschaft != null)
            {
                _Gruppe.Teilnehmer.Remove(mannschaft);
                _Pool.Items.Add(new Listenelement<Mannschaft>(mannschaft, mannschaft.Name));
            }
        }

        private void Mannschaft_entfernen(object sender, EventArgs e)
        {
            Listenelement<Mannschaft> mannschaft = _Gruppenbox.Mannschaften.SelectedItem as Listenelement<Mannschaft>;
            Mannschaft_entfernen(mannschaft.Details);
            Ansicht_aktualisieren();
            Datei_Interakteur.Save_Temp();
        }

        private void Alle_Mannschaften_entfernen(object sender, EventArgs e)
        {
            foreach (var item in _Gruppenbox.Mannschaften.Items)
            {
                Listenelement<Mannschaft> list_mannschaft = item as Listenelement<Mannschaft>;
                Mannschaft_entfernen(list_mannschaft.Details);
            }
            Ansicht_aktualisieren();
            Datei_Interakteur.Save_Temp();
        }

    }
}
