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
            Datei_Interakteur.Folder = Konfiguration.Einstellungen.Speicherordner;
            try
            {
                Datei_Interakteur.File_Name = args[0];
                Datei_Interakteur.Load();
            }
            catch { }
            new Hauptfenster_Interakteur();
        }
            
    }
}
