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
    class Spielpaarungsbaustein_Minified_Interakteur_UntereEbenen : Spielpaarungsbaustein_Minified_Interakteur
    {
        private Runde _Qualifikationsrunde;

        public bool FuerSiegerbaum { get; set; }

        public Spielpaarungsbaustein_Minified_Interakteur_UntereEbenen(Paarung paarung, Runde qualifikationsrunde) : base(paarung) 
        {
            _Qualifikationsrunde = qualifikationsrunde;
            FuerSiegerbaum = true;
        }

        protected override void SetEventListeners()
        {
            _Paarungsfeld.TeamA_Add += NaechstePaarungAusVorrunde_TeamA;
            _Paarungsfeld.TeamA_Remove += VorherigePaarungAusVorrunde_TeamA;
            _Paarungsfeld.TeamB_Add += NaechstePaarungAusVorrunde_TeamB;
            _Paarungsfeld.TeamB_Remove += VorherigePaarungAusVorrunde_TeamB;
        }

        private void NaechstePaarungAusVorrunde_TeamA(object sender, EventArgs e)
        {
            QualifikationsspielSetzen_TeamA(1);
            NotifyPropertyChanged("NameTeamA");
        }

        private void VorherigePaarungAusVorrunde_TeamA(object sender, EventArgs e)
        {
            QualifikationsspielSetzen_TeamA(-1);
            NotifyPropertyChanged("NameTeamA");
        }

        private void QualifikationsspielSetzen_TeamA(int wert)
        {
            try
            {
                Paarung quali_akt = _Qualifikationsrunde.Paarungen.Find(x => x.Name == _Paarung.Vorheriges_Spiel_A.Name);
                int index = _Qualifikationsrunde.Paarungen.IndexOf(quali_akt);
                Paarung quali_neu = _Qualifikationsrunde.Paarungen.ElementAt(index + wert);
                _Paarung.QualifikationsSpielSetzen_TeamA(new Qualifikationsspiel(quali_neu, FuerSiegerbaum));
            }
            catch (ArgumentOutOfRangeException ecx) { }
        }

        private void NaechstePaarungAusVorrunde_TeamB(object sender, EventArgs e)
        {
            QualifikationsspielSetzen_TeamB(1);
            NotifyPropertyChanged("NameTeamB");
        }

        private void VorherigePaarungAusVorrunde_TeamB(object sender, EventArgs e)
        {
            QualifikationsspielSetzen_TeamB(-1);
            NotifyPropertyChanged("NameTeamB");
        }

        private void QualifikationsspielSetzen_TeamB(int wert)
        {
            try
            {
                Paarung quali_akt = _Qualifikationsrunde.Paarungen.Find(x => x.Name == _Paarung.Vorheriges_Spiel_B.Name);
                int index = _Qualifikationsrunde.Paarungen.IndexOf(quali_akt);
                Paarung quali_neu = _Qualifikationsrunde.Paarungen.ElementAt(index + wert);
                _Paarung.QualifikationsSpielSetzen_TeamB(new Qualifikationsspiel(quali_neu, FuerSiegerbaum));
            }
            catch (ArgumentOutOfRangeException ecx) { }
        }
    }
}
