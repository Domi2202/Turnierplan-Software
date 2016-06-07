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
    class Veranstaltungsuebersicht_Interakteur : INotifyPropertyChanged
    {
        private Veranstaltung _Veranstaltung;
        //private Turnier _Turnier; brauchst du natürlich nicht, geht ja um die ganze veranstaltung ;)
        private Grid _Darstellungsbereich;
        private Veranstaltungsuebersicht _Fenster;


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public Veranstaltungsuebersicht_Interakteur(Grid darstellungsbereich, Veranstaltung veranstaltung)
        {
            
            _Darstellungsbereich = darstellungsbereich;
            _Veranstaltung = veranstaltung;
            _Fenster = new Veranstaltungsuebersicht();
            //_Fenster.Visibility = Visibility.Visible; ich denke wir starten fürs erste weiterhin in der Turnieransicht

            Ansicht_Laden();
            _Fenster.DataContext = this;
            _Fenster.IsVisibleChanged += AnsichtAktualisieren;
        }
        private void AnsichtAktualisieren(object sender, DependencyPropertyChangedEventArgs e)
        {
            NotifyPropertyChanged("Name");
            NotifyPropertyChanged("Spiele");


        }

        #region BindingProperties

        public int Anzahl_Spieltage
        {
            get { return _Veranstaltung.Spieltage.Count; }
            set 
            {
                if (_Veranstaltung.Spieltage.Count < value)
                {
                    _Veranstaltung.NeuerSpieltag(value - _Veranstaltung.Spieltage.Count);
                }
                else if (_Veranstaltung.Spieltage.Count > value)
                {
                    _Veranstaltung.Spieltage_loeschen(_Veranstaltung.Spieltage.Count - value);
                }
                NotifyPropertyChanged("Spieltage");
            }
        }
        public int Bespielbare_Felder
        {
            get { return _Veranstaltung.Anzahl_Spielfelder; }
            set { _Veranstaltung.Anzahl_Spielfelder_setzten(value); }
        }

        public int Anzahl_tage
        {
            get { return _Veranstaltung.Spieltage.Count; }
        }

        public string Name
        {
            get { return _Veranstaltung.Name; }
        }

        public int Spiele
        {
            get { return Spieleberechnen(); }
        }

        public IEnumerable<UIElement> Spieltage
        {
            get 
            {
                List<SpieltagBox> spieltagboxen = new List<SpieltagBox>();
                foreach (Spieltag spieltag in _Veranstaltung.Spieltage)
                {
                    spieltagboxen.Add(new Spieltagbox_Interakteur(spieltag).SpieltagBox);
                   
                }
                return spieltagboxen;
            }
        }

        #endregion

        private void Ansicht_Laden()
        {
            _Darstellungsbereich.Children.Add(_Fenster);
        }
        private int Spieleberechnen()
        {
            int counter = 0;
            foreach (Turnier turnier in Datei_Interakteur.Geladene_Veranstaltung.Turniere) 
            {
                counter += turnier.Endrunde.SpielezahlBerechnen() + turnier.Trostrunde.AnzahlSpieleBerechnen() + Spielanzahl_berechnen(turnier);

            }
            return counter;

        }
        private int Spielanzahl_berechnen(Turnier turnier)
        {
            int spiele = 0;
            foreach (Gruppe gruppe in turnier.Gruppen)
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

    }
}
