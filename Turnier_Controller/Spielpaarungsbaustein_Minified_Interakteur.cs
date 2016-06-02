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
    abstract class Spielpaarungsbaustein_Minified_Interakteur : INotifyPropertyChanged
    {
        protected Spielpaarungsbaustein_Minified _Paarungsfeld;
        protected Paarung _Paarung;

        public Spielpaarungsbaustein_Minified Paarungsfeld 
        {
            get { return _Paarungsfeld; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #region WrapperProperties

        public string NameDerPaarung
        {
            get { return _Paarung.Name; }
        }

        public string NameTeamA
        {
            get { return _Paarung.Name_MannschaftA(); }
        }

        public string NameTeamB
        {
            get { return _Paarung.Name_MannschaftB(); }
        }

        #endregion

        public Spielpaarungsbaustein_Minified_Interakteur(Paarung paarung)
        {
            _Paarungsfeld = new Spielpaarungsbaustein_Minified();
            _Paarung = paarung;
            _Paarungsfeld.DataContext = this;
            SetEventListeners();
        }

        public void Platzieren(int col)
        {
            Grid.SetColumn(_Paarungsfeld, col);
        }

        protected abstract void SetEventListeners();
    }
}
