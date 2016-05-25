using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Endrunde : INotifyPropertyChanged
    {
        private Modus _Modus;
        private bool _kleinesFinale;
        private List<ParticipationRule> _ParticipationRules;

        public Endrunde()
        {
            _ParticipationRules = new List<ParticipationRule>();
        }

        #region publicProperties
        public List<ParticipationRule> Teilnahmeregeln
        {
            get { return _ParticipationRules; }
        }
        public Modus Modus
        {
            get { return _Modus; }
            set
            {
                _Modus = value;
                UnsetThirdPlacePlayoffIfNecessary();
                NotifyAllPropertyChanges();
                Datei_Interakteur.Save_Temp();
            }
        }
        public int Anzahl_Teilnehmer
        {
            get { return (int)Modus; }
        }
        public int Anzahl_Spiele
        {
            get { return CalculateNumberOfGames(); }
        }
        public bool Mit_kleinem_Finale
        {
            get { return _kleinesFinale; }
            set
            {
                _kleinesFinale = value;
                NotifyPropertyChanged("Anzahl_Spiele");
                NotifyPropertyChanged("Mit_kleinem_Finale");
                Datei_Interakteur.Save_Temp();
            }
        }
        public bool Kleines_Finale_moeglich
        {
            get
            {
                if (Modus != Modus.Finale)
                {
                    return true;
                }
                else return false;
            }
        }

        public IEnumerable<Modus> Moegliche_Modi
        {
            get { return Enum.GetValues(typeof(Modus)).Cast<Modus>(); }
        }
        public ObservableCollection<string> ParticipationRules
        {
            get
            {
                List<string> rules = new List<string>();
                foreach (ParticipationRule rule in _ParticipationRules)
                {
                    rules.Add(rule.Name);
                }
                ObservableCollection<string> rulesAsStrings = new ObservableCollection<string>(rules);
                return rulesAsStrings;
            }        
        }
        public int PaticipantsProvided
        {
            get { return ParticipationRules.Count; }
        }
        public List<Runde> Runden { get; set; }
        #endregion

        #region privateFunctions

        private int CalculateNumberOfGames()
        {
            int games = 0;
            int teams = (int)Modus;
            while (teams > 1)
            {
                games += teams / 2;
                teams = teams / 2;
            }
            if (Mit_kleinem_Finale) games += 1;
            return games;
        }

        private void UnsetThirdPlacePlayoffIfNecessary()
        {
            if (_Modus == Modus.Finale)
            {
                Mit_kleinem_Finale = false;
            }
        }

        private void NotifyAllPropertyChanges()
        {
            NotifyPropertyChanged("Anzahl_Teilnehmer");
            NotifyPropertyChanged("Anzahl_Spiele");
            NotifyPropertyChanged("Kleines_Finale_moeglich");
        }

        #endregion

        #region publicFunctions

        public void AddNewParticipationRule(ParticipationRule rule)
        {
            ParticipationRule newRule = new ParticipationRule();
            foreach (ParticipationRule.Kandidat kandidat in rule.CriteriaList)
            {
                newRule.AddCriteria(kandidat.Group, kandidat.Rank);
            }
            newRule.Name = rule.Name;
            _ParticipationRules.Add(newRule);
            NotifyPropertyChanged("PaticipantsProvided");
            NotifyPropertyChanged("ParticipationRules");
            Datei_Interakteur.Save_Temp();
        }

        public void DeleteParticipationRule(int index)
        {
            _ParticipationRules.Remove(_ParticipationRules.ElementAt(index));
            NotifyPropertyChanged("PaticipantsProvided");
            NotifyPropertyChanged("ParticipationRules");
            Datei_Interakteur.Save_Temp();
        }

        #endregion

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
        //public List<Paarung> Paarungen { get; set; }
    }

    public class Runde
    {
        public int ID { get; set; }
        public int Anzahl_Paarungen { get; set; }
        public List<Paarung> Paarungen { get; set; }
    }

    public enum Modus { Finale = 2, Halbfinale = 4, Viertelfinale = 8, Achtelfinale = 16, Sechzehntelfinale = 32 }
}
