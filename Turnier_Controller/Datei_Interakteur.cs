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
            File.WriteAllText(File_Name + ".tps.temp", json_serialized);
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
                string veranstaltung_json = File.ReadAllText(Folder + "\\" + File_Name + ".tps");
                Geladene_Veranstaltung = JsonConvert.DeserializeObject<Veranstaltung>(veranstaltung_json);
                if (Daten_aktualisiert != null)
                {
                    Daten_aktualisiert(null, null);
                }
            }
        }

        public static void Delete(string veranstaltungsname)
        {
            if (File_Name == veranstaltungsname)
            {
                Geladene_Veranstaltung = null;
                if (Daten_aktualisiert != null)
                {
                    Daten_aktualisiert(null, null);
                }
            }
            if (File.Exists(Folder + "\\" + veranstaltungsname + ".tps"))
            {
                File.Delete(Folder + "\\" + veranstaltungsname + ".tps");
            }
        }

        public static void Delete_Temp()
        {
            if(File.Exists(File_Name + ".tps.temp"))
            {
                File.Delete(File_Name + ".tps.temp");
            }
        }

        public static List<string> Speicherordner_scannen()
        {
            if (Directory.Exists(Folder))
            {
                string[] veranstaltungen = Directory.GetFiles(Folder);
                List<string> veranstaltungsnamen = new List<string>();
                foreach (string veranstaltung in veranstaltungen)
                {
                    string ohne_ordner = veranstaltung.Substring(veranstaltung.IndexOf('\\') + 1);
                    string ohne_erweiterung = ohne_ordner.Substring(0, ohne_ordner.LastIndexOf(".tps"));
                    veranstaltungsnamen.Add(ohne_erweiterung);
                }
                return veranstaltungsnamen;
            }
            else throw new DirectoryNotFoundException("Es wurden noch keine Veranstaltungen erstellt");
        }
    }
}
