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
    class Spielpaarungsbaustein_Minified_Interakteur : INotifyPropertyChanged
    {
        protected Spielpaarungsbaustein_Minified _Paarungsfeld;
        protected Paarung _Paarung;
        protected ListBox _Pool;

        public EventHandler RegelAusPoolGenommen { get; set; }
        public EventHandler RegelInPoolGelegt { get; set; }

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
            //_Pool = pool;
            _Paarung = paarung;
            _Paarungsfeld.DataContext = this;
            SetEventListeners();
        }

        public void Platzieren(int col)
        {
            Grid.SetColumn(_Paarungsfeld, col);
        }

        private void SetEventListeners()
        {
            _Paarungsfeld.TeamA_Add += TeamA_setzen;
            _Paarungsfeld.TeamB_Add += TeamB_setzen;
            _Paarungsfeld.TeamA_Remove += TeamA_entfernen;
            _Paarungsfeld.TeamB_Remove += TeamB_entfernen;
        }

        private void TeamA_setzen(object sender, EventArgs e)
        {
            if (_Pool.SelectedItem == null) return;
            Listenelement<Teilnahmerregel> listeneintrag = _Pool.SelectedItem as Listenelement<Teilnahmerregel>;
            Teilnahmerregel regel = listeneintrag.Details;
            _Paarung.Regel_Mannschaft_A = regel;
            if (RegelAusPoolGenommen != null)
            {
                RegelAusPoolGenommen(regel, null);
            }
            NotifyPropertyChanged("NameTeamA");
        }

        private void TeamB_setzen(object sender, EventArgs e)
        {
            if (_Pool.SelectedItem == null) return;
            Listenelement<Teilnahmerregel> listeneintrag = _Pool.SelectedItem as Listenelement<Teilnahmerregel>;
            Teilnahmerregel regel = listeneintrag.Details;
            _Paarung.Regel_Mannschaft_B = regel;
            if (RegelAusPoolGenommen != null)
            {
                RegelAusPoolGenommen(regel, null);
            }
            NotifyPropertyChanged("NameTeamB");
        }

        private void TeamA_entfernen(object sender, EventArgs e)
        {
            if (_Paarung.Regel_Mannschaft_A == null) return;
            Teilnahmerregel regel = _Paarung.Regel_Mannschaft_A;
            if (RegelInPoolGelegt != null)
            {
                RegelInPoolGelegt(regel, null);
            }
            _Paarung.Regel_Mannschaft_A = null;
            NotifyPropertyChanged("NameTeamA");
        }

        private void TeamB_entfernen(object sender, EventArgs e)
        {
            if (_Paarung.Regel_Mannschaft_B == null) return;
            Teilnahmerregel regel = _Paarung.Regel_Mannschaft_B;
            if (RegelInPoolGelegt != null)
            {
                RegelInPoolGelegt(regel, null);
            }
            _Paarung.Regel_Mannschaft_B = null;
            NotifyPropertyChanged("NameTeamB");
        }
    }
}
