using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
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
            _Hauptfenster.VeranstaltungErstellen += On_VeranstaltungErstellen;
        }

        private void Ansicht_aktualisieren()
        {
            try
            {
                _Hauptfenster.Label_Veranstaltung.Content = Datei_Interakteur.Geladene_Veranstaltung.Name;
            }
            catch { }
        }

        #region Event Handler

        private void On_DatenAktualisiert(object sender, EventArgs e)
        {
            Ansicht_aktualisieren();
        }

        private void On_VeranstaltungErstellen(object sender, EventArgs e)
        {
            new DialogFensterVeranstaltung_Interakteur();
        }

        #endregion
    }
}
