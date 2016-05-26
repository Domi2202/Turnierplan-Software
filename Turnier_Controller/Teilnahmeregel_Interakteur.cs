using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Turnierklassen;
using Turnierplan_Software;

namespace Turnier_Controller
{
    class Teilnahmeregel_Interakteur : INotifyPropertyChanged
    {
        private Teilnahmeregel_Dialog _Dialog;
        private List<Kandidat_DialogBox_Interakteur> _Kandidaten;
        private Turnier _Turnier;

        public EventHandler RegelListenUpdate { get; set; }

        public Teilnahmeregel_Interakteur(Turnier turnier)
        {
            _Dialog = new Teilnahmeregel_Dialog();
            _Kandidaten = new List<Kandidat_DialogBox_Interakteur>();
            _Turnier = turnier;
            _Dialog.DataContext = _Turnier;
            _Dialog.RegelSpeichern += RegelSpeichern;
            _Dialog.DataContext = this;
            NeuesKriterienFeld();
            _Dialog.Show();
        }

        public ObservableCollection<Kandidat_DialogBox> Dialogfelder
        {
            get
            {
                ObservableCollection<Kandidat_DialogBox> dialogfelder = new ObservableCollection<Kandidat_DialogBox>();
                foreach (Kandidat_DialogBox_Interakteur kandidat in _Kandidaten)
                {
                    dialogfelder.Add(kandidat.Dialogbox);
                }
                return dialogfelder;
            }
        }

        public void KandidatenfeldHinzufuegen(object sender, EventArgs e)
        {           
            Kandidat_DialogBox box = (Kandidat_DialogBox)sender;
            NeuesKriterienFeld();
        }

        private void KandidatenfeldEntfernen(object sender, EventArgs e)
        {
            Kandidat_DialogBox box = (Kandidat_DialogBox)sender;
            _Kandidaten.Remove(_Kandidaten.Find(x => x.Dialogbox == box));
            NotifyPropertyChanged("Dialogfelder");
        }

        public void NeuesKriterienFeld()
        {
            Kandidat_DialogBox_Interakteur kandidat = new Kandidat_DialogBox_Interakteur(_Turnier);
            _Kandidaten.Add(kandidat);
            Kandidat_DialogBox box = kandidat.Dialogbox;
            box.NeuerKandidat += KandidatenfeldHinzufuegen;
            box.KandidatEntfernen += KandidatenfeldEntfernen;
            if(_Kandidaten.Count > 1)
            {
                box.MinusKnopfZeigen();
            }
            NotifyPropertyChanged("Dialogfelder");
        }

        private void RegelSpeichern(object sender, EventArgs e)
        {
            Teilnahmerregel regel = new Teilnahmerregel();
            foreach (Kandidat_DialogBox_Interakteur kandidat in _Kandidaten)
            {
                regel.AddCriteria(kandidat.Gruppe, kandidat.Platzierung);
            }
            if (_Dialog.NameDerRegel.Text != string.Empty)
            {
                regel.Name = _Dialog.NameDerRegel.Text;
            }
            _Turnier.Endrunde.AddNewParticipationRule(regel);
            if (RegelListenUpdate != null)
            {
                RegelListenUpdate(this, null);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }

    class Kandidat_DialogBox_Interakteur : INotifyPropertyChanged
    {
        private Kandidat_DialogBox _Dialogbox;
        private Turnier _Turnier;

        public Kandidat_DialogBox Dialogbox
        {
            get { return _Dialogbox; }
        }
        
        public Kandidat_DialogBox_Interakteur(Turnier turnier)
        {
            _Turnier = turnier;
            _Dialogbox = new Kandidat_DialogBox();
            _Dialogbox.DataContext = this;
            _Dialogbox.Gruppenauswahl.SelectionChanged += TeilnehmerauswahlErneuern;
        }

        private void TeilnehmerauswahlErneuern(object sender, SelectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Teilnehmerauswahl");
        }

        public List<string> Gruppennamen
        {
            get
            {
                List<string> gruppen = new List<string>();
                foreach (Gruppe gruppe in _Turnier.Gruppen)
                {
                    gruppen.Add(gruppe.Name);
                }
                return gruppen;
            }
        }

        public ObservableCollection<int> Teilnehmerauswahl
        {
            get
            {
                ObservableCollection<int> platzierungen = new ObservableCollection<int>();
                for (int i = 1; i <= TeilnehmerzahlDerSelektiertenGruppe; i++)
                {
                    platzierungen.Add(i);
                }
                return platzierungen;
            }
        }

        public int Gruppe
        {
            get
            {
                return _Dialogbox.Gruppenauswahl.SelectedIndex + 1;
            }
        }

        public int Platzierung
        {
            get
            {
                return (int)_Dialogbox.Platzierungen.SelectedItem;
            }
        }

        private int TeilnehmerzahlDerSelektiertenGruppe
        {
            get
            {
                if (_Dialogbox.Gruppenauswahl.SelectedItem != null)
                {
                    return _Turnier.Gruppen.Find(x => x.Name == (string)_Dialogbox.Gruppenauswahl.SelectedItem).Anzahl_Teilnehmer;
                }
                else return 0;
            }
        }

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion 
    }
}
