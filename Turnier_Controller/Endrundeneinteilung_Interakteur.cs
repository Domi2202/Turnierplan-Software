using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Turnierplan_Software;
using Turnierklassen;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Turnier_Controller
{
    class Endrundeneinteilung_Interakteur : INotifyPropertyChanged
    {
        private Turnier _Turnier;
        private Endrundeneinteilung _Fenster;
        private Grid _Darstellungsbereich;

        public Endrundeneinteilung_Interakteur(Grid darstellungsbereich, Turnier turnier)
        {
            _Turnier = turnier;
            _Darstellungsbereich = darstellungsbereich;
            _Fenster = new Endrundeneinteilung();
            Ansicht_Laden();
            Informationen_Laden();
            SetEventListeners();
        }

        #region WrapperPropertiesForDataBindings
        /// <summary>
        /// Delivers selectable modes to serve as combobox content
        /// </summary>
        public IEnumerable<Modus> Moegliche_Modi
        {
            get { return Enum.GetValues(typeof(Modus)).Cast<Modus>(); }
        }
        /// <summary>
        /// Gets or sets the selected mode for the final round
        /// </summary>
        public Modus Modus
        {
            get { return _Turnier.Endrunde.Modus; }
            set
            {
                _Turnier.Endrunde.Modus = value;
                NotifyPropertyChanged("Anzahl_Teilnehmer");
                NotifyPropertyChanged("Anzahl_Spiele");
                NotifyPropertyChanged("Kleines_Finale_moeglich");
                NotifyPropertyChanged("Kleines_Finale");
                NotifyPropertyChanged("Warnfarbe");
                NotifyPropertyChanged("Trostrunde_Teilnehmerzahl");
            }
        }
        /// <summary>
        /// Determines wether a third-place-playoff is possible 
        /// </summary>
        public bool Kleines_Finale_moeglich
        {
            get
            {
                if (_Turnier.Endrunde.Modus != Modus.Finale)
                {
                    return true;
                }
                else return false;
            }
        }
        /// <summary>
        /// Gets the number of games played in the final round
        /// </summary>
        public int Anzahl_Spiele
        {
            get { return CalculateNumberOfGames(); }
        }
        /// <summary>
        /// Gets the number of participants for the selected mode
        /// </summary>
        public int Anzahl_Teilnehmer
        {
            get { return (int)_Turnier.Endrunde.Modus; }
        }
        /// <summary>
        /// gets the current number of participation rules
        /// </summary>
        public int PaticipantsProvided
        {
            get { return _Turnier.Endrunde.Teilnahmeregeln.Count; }
        }
        /// <summary>
        /// Gets a observeable list of all current participation rules names
        /// </summary>
        public ObservableCollection<string> ParticipationRules
        {
            get
            {
                List<string> rules = new List<string>();
                foreach (Teilnahmerregel rule in _Turnier.Endrunde.Teilnahmeregeln)
                {
                    rules.Add(rule.Name);
                }
                ObservableCollection<string> rulesAsStrings = new ObservableCollection<string>(rules);
                return rulesAsStrings;
            }
        }
        /// <summary>
        /// Gets or sets wether a third-place-playoff is played in the final round
        /// </summary>
        public bool Kleines_Finale
        {
            get { return _Turnier.Endrunde.Kleines_Finale; }
            set
            {
                _Turnier.Endrunde.Kleines_Finale = value;
                NotifyPropertyChanged("Anzahl_Spiele");
                NotifyPropertyChanged("Kleines_Finale");
            }
        }
        /// <summary>
        /// Gets a red brush when participant count doesnt match participation rule count, else gets a black brush
        /// </summary>
        public Brush Warnfarbe
        {
            get
            {
                if (_Turnier.Endrunde.Teilnahmeregeln.Count != Anzahl_Teilnehmer)
                {
                    return Brushes.IndianRed;
                }
                else return Brushes.Black;
            }
        }
        /// <summary>
        /// Gets or sets wether the consolation round is played as a playoff round
        /// </summary>
        public bool Trostrunde_mit_Playoffs
        {
            get { return _Turnier.Trostrunde.Playoffs != null; }
            set
            {
                _Turnier.Trostrunde.Playoffs_setztenOderZerstören();
                NotifyPropertyChanged("Trostrunde_mit_Playoffs");
                NotifyPropertyChanged("Trostrunde_JederGegenJeden");
                NotifyPropertyChanged("Trostrunde_Spielezahl");
            }
        }
        /// <summary>
        /// Gets or sets wether the consolation round is played as a group round
        /// </summary>
        public bool Trostrunde_JederGegenJeden
        {
            get { return _Turnier.Trostrunde.JederGegenJeden != null; }
            set
            {
                _Turnier.Trostrunde.JederGegenJeden_setztenOderZerstören(Trostrunde_Teilnehmerzahl);
                NotifyPropertyChanged("Trostrunde_mit_Playoffs");
                NotifyPropertyChanged("Trostrunde_JederGegenJeden");
                NotifyPropertyChanged("Trostrunde_Spielezahl");
            }
        }
        /// <summary>
        /// Gets the number of participants in consolation round
        /// </summary>
        public int Trostrunde_Teilnehmerzahl
        {
            get { return _Turnier.Mannschaften.Count - (int)_Turnier.Endrunde.Modus; }
        }
        /// <summary>
        /// Gets the number of games played in consolation round
        /// </summary>
        public int Trostrunde_Spielezahl
        {
            get { return _Turnier.Trostrunde.AnzahlSpieleBerechnen(); }
        }
        /// <summary>
        /// Gets and sets the mode for the consolation round
        /// </summary>
        public Modus Trostrunde_Modus
        {
            get
            {
                if (_Turnier.Trostrunde.Playoffs != null)
                {
                    return _Turnier.Trostrunde.Playoffs.Modus;
                }
                else return Modus.Viertelfinale;
            }
            set
            {
                _Turnier.Trostrunde.Playoffs.Modus = value;
                NotifyPropertyChanged("Trostrunde_Spielezahl");
            }
        }
        #endregion

        #region PrivateFunctions

        private void Ansicht_Laden()
        {
            _Darstellungsbereich.Children.Add(_Fenster);
        }

        private void Informationen_Laden()
        {
            _Fenster.DataContext = this;
            _Fenster.label_Turniername.DataContext = _Turnier;
        }

        private void SetEventListeners()
        {
            _Fenster.AddParticipationRule += AddParticipationRule;
            _Fenster.DeleteParticipationRule += DeleteParticipationRule;
            _Fenster.TeilnahmeregelAnzeigen += TeilnahmeregelAnzeigen;
        }

        private int CalculateNumberOfGames()
        {
            int games = 0;
            int teams = (int)_Turnier.Endrunde.Modus;
            while (teams > 1)
            {
                games += teams / 2;
                teams = teams / 2;
            }
            if (_Turnier.Endrunde.Kleines_Finale) games += 1;
            return games;
        }
        #endregion

        #region PublicFunctions

        public void DeleteParticipationRule(int index)
        {
            _Turnier.Endrunde.DeleteParticipationRule(index);
            NotifyPropertyChanged("PaticipantsProvided");
            NotifyPropertyChanged("ParticipationRules");
            NotifyPropertyChanged("Warnfarbe");
        }

        #endregion

        #region EventHandler

        private void DeleteParticipationRule(object sender, EventArgs e)
        {
            if (_Fenster.listbox_Teilnehmer.SelectedItem != null)
            {
                DeleteParticipationRule(_Fenster.listbox_Teilnehmer.SelectedIndex);
            }
        }

        private void AddParticipationRule(object sender, EventArgs e)
        {
            Teilnahmeregel_Interakteur fenster = new Teilnahmeregel_Interakteur(_Turnier);
            fenster.RegelListenUpdate += NeueRegelWurdeHinzugefuegt;
        }

        private void TeilnahmeregelAnzeigen(object sender, EventArgs e)
        {
            if (_Fenster.listbox_Teilnehmer.SelectedItem != null)
            {
                Teilnahmerregel regel = _Turnier.Endrunde.Teilnahmeregeln.ElementAt(_Fenster.listbox_Teilnehmer.SelectedIndex);
                string info = string.Empty;
                foreach (Teilnahmerregel.Kandidat kandidat in regel.CriteriaList)
                {
                    info += kandidat.Rank + ". Gruppe " + kandidat.Group + "\noder\n";
                }
                info = info.TrimEnd('r', 'e', 'd', 'o', '\n');
                new FehlerFenster(info).Show();
            }          
        }

        public void NeueRegelWurdeHinzugefuegt(object sender, EventArgs e)
        {
            NotifyPropertyChanged("PaticipantsProvided");
            NotifyPropertyChanged("ParticipationRules");
            NotifyPropertyChanged("Warnfarbe");
        }


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
