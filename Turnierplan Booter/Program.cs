using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Turnier_Controller;

namespace TurnierplanBooter
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Konfiguration.Lese_Einstellungen();
            new Hauptfenster_Interakteur(args); 
        }
            
    }
}
