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
        public int Anzahl_Spielfelder { get; private set; }
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

        public void NeuerSpieltag( int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Spieltag tag = new Spieltag();
                tag.Name = Convert.ToString(Spieltage.Count + 1) + ". Spieltag";
                Spieltage.Add(tag);
            }
            Datei_Interakteur.Save_Temp();
        }

        public void Spieltage_loeschen(int n)
        {
            for (int i = n; i > 0; i--)
            {
                if (Spieltage.Count == 0)
                {
                    return;
                }
                Spieltage.Remove(Spieltage.Last());
            }
            Datei_Interakteur.Save_Temp();
        }   
    }

    public class Spieltag
    {
        public DateTime Startzeit { get; set; }
        public DateTime Endezeit { get; set; }
        public string Name { get; set; }

        public Spieltag() 
        {
            Startzeit = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            Endezeit = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }

        public Spieltag(DateTime start, DateTime ende)   
        {
            Startzeit = start;
            Endezeit = ende;
        }

        public void DatumSetzen(DateTime datum) 
        {
            Startzeit = new DateTime(datum.Year, datum.Month, datum.Day, Startzeit.Hour, Startzeit.Minute, 0);
            Endezeit = new DateTime(datum.Year, datum.Month, datum.Day, Endezeit.Hour, Endezeit.Minute, 0);
            Datei_Interakteur.Save_Temp();
        }

        public void Startzeit_Stunde_setzen(int stunde)
        {
            Startzeit = new DateTime(Startzeit.Year, Startzeit.Month, Startzeit.Day, stunde, Startzeit.Minute, 0);
            Datei_Interakteur.Save_Temp();
        }
        public void Startzeit_Minute_setzen(int minute)
        {
            Startzeit = new DateTime(Startzeit.Year, Startzeit.Month, Startzeit.Day, Startzeit.Hour, minute, 0);
            Datei_Interakteur.Save_Temp();
        }
        public void Endezeit_Stunde_setzen(int stunde)
        {
            Endezeit = new DateTime(Endezeit.Year, Endezeit.Month, Endezeit.Day, stunde, Endezeit.Minute, 0);
            Datei_Interakteur.Save_Temp();
        }
        public void Endezeit_Minute_setzen(int minute)
        {
            Endezeit = new DateTime(Endezeit.Year, Endezeit.Month, Endezeit.Day,Endezeit.Hour, minute, 0);
            Datei_Interakteur.Save_Temp();
        }

    }

    public class Slot
    {
        public DateTime Uhrzeit { get; set; }
        public int Feld { get; set; }
        public Paarung Paarung { get; set; }
    }
}
