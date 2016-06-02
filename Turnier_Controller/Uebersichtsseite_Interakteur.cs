using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Turnierplan_Software;
using Turnierklassen;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Turnier_Controller
{
    class Uebersichtsseite_Interakteur : INotifyPropertyChanged
    {
        private Turnier _Turnier;
        private übersichtsseite _Fenster;
        private Grid _Darstellungsbereich;
       

        public Uebersichtsseite_Interakteur(Grid darstellungsbereich, Turnier turnier)
        {
            _Turnier = turnier;
            _Darstellungsbereich = darstellungsbereich;
            _Fenster = new übersichtsseite();
            Ansicht_Laden();
            _Fenster.DataContext = this;
            _Fenster.IsVisibleChanged += AnsichtAktualisieren;


        }
       public int Zeit_Halbzeit_Minuten
        {

            get
            {
                return _Turnier.Halbzeitdauer.Minutes;
            }
            set
            {
                _Turnier.HalbzeitMinutenSetzen(value);
            }
        }
       public int Zeit_Halbzeit_Sekunden
       {

           get
           {

               return _Turnier.Halbzeitdauer.Seconds;
           }
           set
           {
               _Turnier.Halbzeitsekundensetzten(value);
           }
       }

       public int Zeit_Pausendauert_Sekunden
       {

           get
           {

               return _Turnier.Pausendauer.Seconds;
           }
           set
           {
               _Turnier.Pausensekundensetzten(value);
           }
       }
       public int Zeit_Pausendauer_Minuten
       {

           get
           {

               return _Turnier.Pausendauer.Minutes;
           }
           set
           {
               _Turnier.Pausenminutensetzten(value);
           }
       }
        

        
        

        public string Name
        {
            get { return _Turnier.Name; }
            
        }

        public int Anzahl_Trostrundenspiele
        {
            get { return _Turnier.Trostrunde.AnzahlSpieleBerechnen(); }
        }

        public string Endrundenmodus
        {
            get { return Convert.ToString(_Turnier.Endrunde.Modus); }


        }

        public int Anzahl_Spiele
        {
            get { return _Turnier.Endrunde.SpielezahlBerechnen(); }
        }
        public int Anzahl_Spiele_Gesamt
        {
            get { return Spielanzahl_gesamt_berechnen(); }

        }

        public string Trostrunde_Modus
        {
            get {

                if (_Turnier.Trostrunde.JederGegenJeden_Aktiv)
                {
                    return "Jeder gegen Jeden";

                }
                else
                {
                    return "Playoffs";

                }
            
            }
        }

        public int Gruppenzahl
        {
            get { return _Turnier.Gruppen.Count; }

        }

        /*public string Trostrundenodus
        {
            get{return Convert.ToString(_Turnier.Trostrunde.AnzahlSpieleBerechnen)
        }*/

        public int Mannschaftszahl
        {
            get { return _Turnier.Mannschaften.Count; }
        }
        /*public int anzahl_spiele
        {
            get{return _Turnier.Gruppen
        }*/
        public int Gruppenspielzahl
        {
            get { return Spielanzahl_berechnen(); }
        }

        public IEnumerable<Geschlecht> Moegliche_Geschlechter
        {
            get { return Enum.GetValues(typeof(Geschlecht)).Cast<Geschlecht>(); }
        }


        public IEnumerable<Altersgruppe> Moegliche_Altersgruppen
        {
            get { return Enum.GetValues(typeof(Altersgruppe)).Cast<Altersgruppe>(); }
           

        }


        private void Ansicht_Laden()
        {
            _Darstellungsbereich.Children.Add(_Fenster);
        }

        private void AnsichtAktualisieren(object sender, DependencyPropertyChangedEventArgs e)
        {
            NotifyPropertyChanged("Mannschaftszahl");
            NotifyPropertyChanged("Endrundenmodus");
            NotifyPropertyChanged("Gruppenspielzahl");
            NotifyPropertyChanged("Gruppenzahl");
            NotifyPropertyChanged("Anzahl_Spiele");
            NotifyPropertyChanged("Anzahl_Trostrundenspiele");
            NotifyPropertyChanged("Anzahl_Spiele_Gesamt");
            NotifyPropertyChanged("Trostrunde_Modus");







        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public Geschlecht geschlecht
        {
            get { return _Turnier.Geschlecht; }
            set { _Turnier.Geschlecht = value; }


        }
        
        public Altersgruppe altersgruppe
        {
            get { return _Turnier.Altersgruppe; }
            set {_Turnier.Altersgruppe = value; }
        }



        private int Spielanzahl_berechnen()
        {
            int spiele = 0;
            foreach (Gruppe gruppe in _Turnier.Gruppen)
            {
                int n = gruppe.Anzahl_Teilnehmer - 1;
                while (n > 0)
                {
                    spiele += n;
                    n--;
                }
            }
            return spiele;
        }

        private int Spielanzahl_gesamt_berechnen()
        {
            int spiele = 0;
            spiele = Anzahl_Spiele + Anzahl_Trostrundenspiele + Gruppenspielzahl;
                return spiele;


        }



    }
}
