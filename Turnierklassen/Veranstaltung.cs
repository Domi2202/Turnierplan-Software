using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Veranstaltung
    {
        public string Name { get; set; }
        public int Anzahl_Spielfelder { get; set; }
        public List<Turnier> Turniere { get; set; }
        public List<Spieltag> Spieltage { get; set; }
        public List<Slot> Spielplan { get; set; }

        public Veranstaltung()
        {
            Turniere = new List<Turnier>();
            Spieltage = new List<Spieltag>();
            Spielplan = new List<Slot>();
        }
        public void Anzahl_Spielfelder_setzten(int anzahl)
        {
            Anzahl_Spielfelder = anzahl;
            Datei_Interakteur.Save_Temp();
        }
    }

    public class Spieltag
    {
        public DateTime Startzeit { get; set; }
        public DateTime Endezeit { get; set; }
    }

    public class Slot
    {
        public DateTime Uhrzeit { get; set; }
        public int Feld { get; set; }
        public Paarung Paarung { get; set; }
    }
}
