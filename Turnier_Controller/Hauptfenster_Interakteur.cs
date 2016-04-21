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
            Ansicht_aktualisieren();
            Show_Window();
        }

        private void Show_Window()
        {
            _Programm.Run(_Hauptfenster);
        }

        private void Set_Event_Listeners()
        {
            Datei_Interakteur.Daten_aktualisiert += On_DatenAktualisiert;
            _Hauptfenster.ProgrammBeenden += On_ProgrammBeenden;
            _Hauptfenster.Speichern += On_Speichern;
            _Hauptfenster.VeranstaltungErstellen += On_VeranstaltungErstellen;
            _Hauptfenster.TurnierHinzufuegen += On_TurnierHinzufuegen;
        }

        #region Ansicht

        private void Ansicht_aktualisieren()
        {
            try
            {
                Veranstaltungsnamen_setzen();
                Turnierliste_bereinigen();
                Turnierliste_aufbauen();
            }
            catch { }
        }

        private void Veranstaltungsnamen_setzen()
        {
            _Hauptfenster.Label_Veranstaltung.Content = Datei_Interakteur.Geladene_Veranstaltung.Name;
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

        #endregion Ansicht

        #region Event Handler

        private void On_DatenAktualisiert(object sender, EventArgs e)
        {
            Ansicht_aktualisieren();
        }

        private void On_VeranstaltungErstellen(object sender, EventArgs e)
        {
            new DialogFensterVeranstaltung_Interakteur();
        }

        private void On_TurnierHinzufuegen(object sender, EventArgs e)
        {
            new DialogFensterTurnier_Interakteur();
        }

        private void On_Speichern(object sender, EventArgs e)
        {
            Datei_Interakteur.Save();
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

        private void On_Shutdown(object sender, EventArgs e)
        {
            Datei_Interakteur.Delete_Temp();
            _Programm.Shutdown();
        }

        #endregion
    }
}
