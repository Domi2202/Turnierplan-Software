using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Turnier_Controller
{
    public static class Konfiguration
    {
        public static Einstellungen Einstellungen { get; set; }
        public static void Lese_Einstellungen()
        {
            if (File.Exists("config.txt") == false)
            {
                Einstellungen standard_einstellugen = new Einstellungen();
                string standard_conf = JsonConvert.SerializeObject(standard_einstellugen);
                File.WriteAllText("config.txt", standard_conf);
            }
            string conf = File.ReadAllText("config.txt");
            Einstellungen = JsonConvert.DeserializeObject<Einstellungen>(conf);
        }
        public static void Speichern()
        {
            File.WriteAllText("config.txt", JsonConvert.SerializeObject(Einstellungen));
        }
    }

    public class Einstellungen
    {
        public string Speicherordner { get; set; }

        public Einstellungen()
        {
            Speicherordner = "saves";
        }
    }
}
