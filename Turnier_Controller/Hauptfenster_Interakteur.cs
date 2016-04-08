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
            Show_Window();
        }

        private void Show_Window()
        {
            _Programm.Run(_Hauptfenster);
        }

        private void Set_Event_Listeners()
        {
            _Hauptfenster.VeranstaltungErstellen += On_VeranstaltungErstellen;
        }

        #region Event Handler

        private void On_VeranstaltungErstellen(object sender, EventArgs e)
        {
            new DialogFensterVeranstaltung_Interakteur();
        }

        #endregion
    }
}
