using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Turnierklassen;
using System.IO;
using System.Diagnostics;

namespace Turnierklassen
{
    public static class Datei_Interakteur
    {
        private static bool _All_Saved = true;
        public static string Folder { get; set; }
        public static string File_Name { get; set; }
        public static EventHandler Aktualisierung_erforderlich { get; set; }
        public static EventHandler Daten_gespeichert { get; set; }
        public static EventHandler Speichern_erforderlich { get; set; }
        public static Veranstaltung Geladene_Veranstaltung { get; set; }
        public static bool All_Saved { get { return _All_Saved; } }

        public static void Save()
        {
            if (File_Name != null)
            {
                Directory.CreateDirectory(Folder);
                string json_serialized = JsonConvert.SerializeObject(Geladene_Veranstaltung);
                File.WriteAllText(Folder + "\\" + File_Name + ".tps", json_serialized);
                Delete_Temp();
                _All_Saved = true;
                if (Daten_gespeichert != null)
                {
                    Daten_gespeichert(null, null);
                }
            }
        }

        public static void Save_Temp()
        {
            string json_serialized = JsonConvert.SerializeObject(Geladene_Veranstaltung);
            File.WriteAllText("tps.temp", json_serialized);
            if(_All_Saved == true)
            {
                Speicherbenachrichtigung_geben();
            }
        }

        public static void Load()
        {
            if (File.Exists(Folder + "\\" + File_Name + ".tps"))
            {
                string veranstaltung_json = File.ReadAllText(Folder + "\\" + File_Name + ".tps");
                Geladene_Veranstaltung = JsonConvert.DeserializeObject<Veranstaltung>(veranstaltung_json);
                _All_Saved = true;
            }
        }

        public static void Load(string file)
        {
            if (File.Exists(file))
            {
                string veranstaltung_json = File.ReadAllText(file);
                Geladene_Veranstaltung = JsonConvert.DeserializeObject<Veranstaltung>(veranstaltung_json);
                File_Name = Geladene_Veranstaltung.Name;
            }
        }

        public static void Delete(string veranstaltungsname)
        {
            if (File_Name == veranstaltungsname)
            {
                Delete_Temp();
                Geladene_Veranstaltung = null;
                File_Name = null;
                _All_Saved = true;
                if (Aktualisierung_erforderlich != null)
                {
                    Aktualisierung_erforderlich(null, null);
                }
            }
            if (File.Exists(Folder + "\\" + veranstaltungsname + ".tps"))
            {
                File.Delete(Folder + "\\" + veranstaltungsname + ".tps");
            }
        }

        public static void Delete_Temp()
        {
            if(File.Exists("tps.temp"))
            {
                File.Delete("tps.temp");
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
            else return new List<string>();
        }

        public static bool Wiederherstellungsdatei_vorhanden()
        {
            return File.Exists("tps.temp");
        }

        public static void Wiederherstellungsdatei_laden()
        {
            Load("tps.temp");
            Speicherbenachrichtigung_geben();
        }

        public static void Speicherbenachrichtigung_geben()
        {
            if (Speichern_erforderlich != null)
            {
                Speichern_erforderlich(null, null);
            }
            _All_Saved = false;
        }

        public static bool Name_verfügbar(Veranstaltung neue_veranstaltung)
        {
            if (File.Exists(Folder + "\\" + neue_veranstaltung.Name + ".tps"))
            {
                return false;
            }
            else return true;
        }

        public static bool Name_verfügbar(Turnier neues_Turnier)
        {
            if (Geladene_Veranstaltung.Turniere.Exists(x => x.Name == neues_Turnier.Name))
            {
                return false;
            }
            else return true;
        }

        public static bool Name_verfügbar(Mannschaft neue_Mannschaft, Turnier turnier)
        {
            if (turnier.Mannschaften.Exists(x => x.Name == neue_Mannschaft.Name))
            {
                return false;
            }
            else return true;
        }
    }
}
