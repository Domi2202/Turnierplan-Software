using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Turnierklassen;
using System.IO;
using System.Diagnostics;

namespace Turnier_Controller
{
    public static class Datei_Interakteur
    {
        public static string Path { get; set; }
        public static EventHandler Daten_aktualisiert { get; set; }
        public static Veranstaltung Geladene_Veranstaltung { get; set; }

        public static void Save()
        {
            string json_serialized = JsonConvert.SerializeObject(Geladene_Veranstaltung);
            File.WriteAllText(Path, json_serialized);
        }

        public static void Save_Temp()
        {
            string json_serialized = JsonConvert.SerializeObject(Geladene_Veranstaltung);
            File.WriteAllText(Path + ".temp", json_serialized);
            if ( Daten_aktualisiert != null)
            {
                Daten_aktualisiert(null, null);
            }
        }

        public static void Load()
        {
            if (File.Exists(Path))
            {
                string veranstaltung_json = File.ReadAllText(Path);
                Geladene_Veranstaltung = JsonConvert.DeserializeObject<Veranstaltung>(veranstaltung_json);
            }
        }
    }
}
