using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace TurnierplanBooter
{
    class Konfiguration
    {
        public Einstellungen Einstellungen { get; set; }
        public void Lese_Einstellungen()
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
    }

    class Einstellungen
    {
        public string Speicherordner { get; set; }

        public Einstellungen()
        {
            Speicherordner = "saves";
        }
    }
}
