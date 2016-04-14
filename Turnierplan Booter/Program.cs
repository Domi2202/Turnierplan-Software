using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnier_Controller;

namespace TurnierplanBooter
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Datei_Interakteur.Path = args[0];
                Datei_Interakteur.Load();
            }
            catch {}
            new Hauptfenster_Interakteur();
        }
    }
}
