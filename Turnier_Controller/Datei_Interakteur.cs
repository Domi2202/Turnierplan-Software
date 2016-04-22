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
        private static bool _All_Saved = true;
        public static string Folder { get; set; }
        public static string File_Name { get; set; }
        public static EventHandler Daten_aktualisiert { get; set; }
        public static Veranstaltung Geladene_Veranstaltung { get; set; }
        public static bool All_Saved { get { return _All_Saved; } }

        public static void Save()
        {
            Directory.CreateDirectory(Folder);
            string json_serialized = JsonConvert.SerializeObject(Geladene_Veranstaltung);
            File.WriteAllText(Folder + "\\" + File_Name + ".tps", json_serialized);
            _All_Saved = true;
        }

        public static void Save_Temp()
        {
            Directory.CreateDirectory(Folder);
            string json_serialized = JsonConvert.SerializeObject(Geladene_Veranstaltung);
            File.WriteAllText(Folder + "\\" + File_Name + ".tps.temp", json_serialized);
            if ( Daten_aktualisiert != null)
            {
                Daten_aktualisiert(null, null);
            }
            _All_Saved = false;
        }

        public static void Load()
        {
            if (File.Exists(Folder + "\\" + File_Name + ".tps"))
            {
                string veranstaltung_json = File.ReadAllText(Folder + "\\" + File_Name);
                Geladene_Veranstaltung = JsonConvert.DeserializeObject<Veranstaltung>(veranstaltung_json);
            }
        }

        public static void Delete_Temp()
        {
            if(File.Exists(Folder + "\\" + File_Name + ".tps.temp"))
            {
                File.Delete(Folder + "\\" + File_Name + ".tps.temp");
            }
        }
    }
}
