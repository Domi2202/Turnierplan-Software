using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows;
using Turnierplan_Software;
using Turnierklassen;

namespace Turnier_Controller
{
    public class Hauptfenster_Interakteur
    {
        private Application _Programm;
        private MainWindow _Hauptfenster;

        public Hauptfenster_Interakteur()
        {
            _Programm = new Application();
            _Hauptfenster = new MainWindow();
            Set_Event_Listeners();
            if (Datei_Interakteur.Wiederherstellungsdatei_vorhanden())
            {
                new AnfrageFenster_Wiederherstellen(On_Daten_wiederhergestellt, _Programm);
            }
            else
            {
                Ansicht_aktualisieren();
                Show_Window();
            }
        }

        private void Show_Window()
        {
            _Programm.Run(_Hauptfenster);
        }

        private void Set_Event_Listeners()
        {
            Datei_Interakteur.Aktualisierung_erforderlich += On_Aktualisierung_erforderlich;
            Datei_Interakteur.Daten_gespeichert += Veranstaltungsnamen_setzen;
            Datei_Interakteur.Speichern_erforderlich += Veranstaltungsname_Stern_setzen;
            _Hauptfenster.ProgrammBeenden += On_ProgrammBeenden;
            _Hauptfenster.Speichern += On_Speichern;
            _Hauptfenster.Laden += On_Laden;
            _Hauptfenster.TurnierHinzufuegen += On_TurnierHinzufuegen;
            _Hauptfenster.TurnierLoeschen += TurnierLoeschen;
            _Hauptfenster.Turnierliste.SelectionChanged += On_Turnier_angeklickt;
        }


        #region Ansicht

        private void Ansicht_aktualisieren()
        {
            Turnierliste_bereinigen();
            Veranstaltungsnamen_bereinigen();
            Informationsgitter_bereinigen();

            if (Datei_Interakteur.Geladene_Veranstaltung != null)
            {
                Veranstaltungsnamen_setzen();
                Turnierliste_aufbauen();
            }
        }

        private void Veranstaltungsnamen_setzen()
        {
            _Hauptfenster.Label_Veranstaltung.Content = Datei_Interakteur.Geladene_Veranstaltung.Name;
        }

        private void Veranstaltungsnamen_bereinigen()
        {
            _Hauptfenster.Label_Veranstaltung.Content = "Keine Veranstaltung geladen";
        }

        private void Turnierliste_bereinigen()
        {
            _Hauptfenster.Turnierliste.Items.Clear();
        }

        private void Turnierliste_aufbauen()
        {
            foreach (Turnier turnier in Datei_Interakteur.Geladene_Veranstaltung.Turniere)
            {
                _Hauptfenster.Turnierliste.Items.Add(new Listenelement<Turnier>(turnier, turnier.Name));
            }
        }

        private void Informationsgitter_bereinigen()
        {
            _Hauptfenster.Grid_Mannschaften.Children.Clear();
            _Hauptfenster.Grid_Gruppeneinteilung.Children.Clear();
            _Hauptfenster.Grid_Endrunde.Children.Clear();
        }

        #endregion Ansicht

        #region Event Handler

        private void Veranstaltungsnamen_setzen(object sender, EventArgs e)
        {
            Veranstaltungsnamen_setzen();
        }

        private void Veranstaltungsname_Stern_setzen(object sender, EventArgs e)
        {
            _Hauptfenster.Label_Veranstaltung.Content += "*";
        }

        private void Turnierliste_erneuern(object sender, EventArgs e)
        {
            Turnierliste_bereinigen();
            Turnierliste_aufbauen();
            _Hauptfenster.Turnierliste.SelectedItem = _Hauptfenster.Turnierliste.Items.GetItemAt(_Hauptfenster.Turnierliste.Items.Count - 1);
        }

        private void On_Daten_wiederhergestellt(object sender, EventArgs e)
        {
            Ansicht_aktualisieren();
            if (Datei_Interakteur.Geladene_Veranstaltung != null)
            {
                Veranstaltungsname_Stern_setzen(this, null);
            }
            _Hauptfenster.Show();
        }

        private void On_Aktualisierung_erforderlich(object sender, EventArgs e)
        {
            Ansicht_aktualisieren();
        }

        private void On_TurnierHinzufuegen(object sender, EventArgs e)
        {
            new DialogFensterTurnier_Interakteur(Turnierliste_erneuern);
        }

        private void TurnierLoeschen(object sender, EventArgs e)
        {
            Listenelement<Turnier> zu_loeschen = _Hauptfenster.Turnierliste.SelectedItem as Listenelement<Turnier>;
            if(zu_loeschen != null)
            {
                Datei_Interakteur.Geladene_Veranstaltung.Turniere.Remove(zu_loeschen.Details);
                Informationsgitter_bereinigen();
                Turnierliste_bereinigen();
                Turnierliste_aufbauen();
                Datei_Interakteur.Save_Temp();
            }
        }

        private void On_Speichern(object sender, EventArgs e)
        {
            Datei_Interakteur.Save();
        }

        private void On_Laden(object sender, EventArgs e)
        {
            if(_Programm.Windows.Count != 1)
            {
                new FehlerFenster("Bitte schließen Sie zunächste alle offenen Dialoge!").Show();
            }
            else
            {
                new Veranstaltungsmanager_Interakteur(On_Aktualisierung_erforderlich);
            }
        }

        private void On_ProgrammBeenden(object sender, CancelEventArgs e)
        {
            if (!Datei_Interakteur.All_Saved)
            {
                e.Cancel = true;
                AnfrageFenster_Speichern anfrage = new AnfrageFenster_Speichern(On_Shutdown);
            }
            else
            {
                On_Shutdown(this, null);
            }
            
        }

        private void On_Turnier_angeklickt(object sender, EventArgs e)
        {
            Listenelement<Turnier> angeklickt = _Hauptfenster.Turnierliste.SelectedItem as Listenelement<Turnier>;
            if (angeklickt != null)
            {
                Informationsgitter_bereinigen();
                new Turnierfenster_Interakteur(_Hauptfenster.Grid_Mannschaften, angeklickt.Details);
                new Gruppeneinteilung_Interakteur(_Hauptfenster.Grid_Gruppeneinteilung, angeklickt.Details);
                new Endrundeneinteilung_Interakteur(_Hauptfenster.Grid_Endrunde, angeklickt.Details);
            }
        }

        private void On_Shutdown(object sender, EventArgs e)
        {
            _Programm.Shutdown();
        }

        #endregion
    }
}
