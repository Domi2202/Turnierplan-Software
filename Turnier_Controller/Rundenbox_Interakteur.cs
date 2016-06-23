using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using Turnierklassen;
using Turnierplan_Software;
using System.Windows.Controls;

namespace Turnier_Controller
{
    class Rundenbox_Interakteur : INotifyPropertyChanged
    {
        private Runde _Runde;
        private Endrunde _Endrunde;
        private RundenBox _Box;

        public EventHandler NeueRunde { get; set; }
        public EventHandler RundeLoeschen { get; set; }

        public RundenBox Box
        {
            get { return _Box; }
        }

        public Rundenbox_Interakteur(Runde runde, Endrunde endrunde)
        {
            _Runde = runde;
            _Endrunde = endrunde;
            _Box = new RundenBox();
            _Box.DataContext = this;
            _Box.Nachfolgerrunde = NeueRundeHinzufuegen;
            _Box.RundeEntfernen = DieseRundeLoeschen;
            SpieleboxenErzeugen();
        }

        #region WrapperProperties

        public string Name
        {
            get { return _Runde.Name; }
        }

        public int Anzahl_Spiele
        {
            get { return _Runde.GetSpielezahl(); }
        }

        public bool Siegerrunde
        {
            get { return _Runde.Siegerrunde; }
            set
            {
                _Runde.SetSiegerrunde(value);
                _Runde.SpieleBelegen(_Endrunde.RundeMitID(_Runde.Vorgaenerrunde));
                SpieleboxenErzeugen();
            }
        }

        public List<DropdownElement<Runde>> MoeglicheVorgaengerrunden
        {
            get
            {
                List<DropdownElement<Runde>> rundenNamen = new List<DropdownElement<Runde>>();
                rundenNamen.Add(new DropdownElement<Runde>(null, "<keine>"));
                foreach(Runde runde in _Endrunde.Runden)
                {
                    DropdownElement<Runde> elem = new DropdownElement<Runde>(runde, runde.Name);
                    rundenNamen.Add(elem);
                }
                return rundenNamen;
            }
        }

        public int Vorgaengerrunde
        {
            get
            {
                try
                {
                    Runde vorgaengerrunde = _Endrunde.RundeMitID(_Runde.Vorgaenerrunde);
                    return _Endrunde.Runden.IndexOf(vorgaengerrunde) + 1;
                }
                catch(KeyNotFoundException e)
                {
                    return 0;
                }
            }
            set
            {
                if (value == 0)
                {
                    _Runde.SetVorgaengerRunde(Guid.Empty);
                }
                else
                {
                    _Runde.SetVorgaengerRunde(_Endrunde.Runden.ElementAt(value - 1).ID);
                }
            }
        }

        public void SpieleboxenErzeugen()
        {
            _Box.Spiele.Children.Clear();
            _Box.Spiele.ColumnDefinitions.Clear();
            int i = 0;
            foreach (Paarung paarung in _Runde.Paarungen)
            {
                try
                {                 
                    Spielpaarungsbaustein_Minified_Interakteur_Qualifikationsrunde spielebox = new Spielpaarungsbaustein_Minified_Interakteur_Qualifikationsrunde(paarung, _Endrunde.RundeMitID(_Runde.Vorgaenerrunde));
                    spielebox.FuerSiegerbaum = _Runde.Siegerrunde;
                    _Box.Spiele.ColumnDefinitions.Add(new ColumnDefinition());
                    _Box.Spiele.Children.Add(spielebox.Paarungsfeld);
                    spielebox.Platzieren(i);
                    i++;
                }
                catch (KeyNotFoundException exc)
                {
                    Spielpaarungsbaustein_Minified_Interakteur_ObereEbene spielebox = new Spielpaarungsbaustein_Minified_Interakteur_ObereEbene(paarung, new ListBox());
                    _Box.Spiele.ColumnDefinitions.Add(new ColumnDefinition());
                    _Box.Spiele.Children.Add(spielebox.Paarungsfeld);
                    spielebox.Platzieren(i);
                    i++;
                }
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public void NeueRundeHinzufuegen(object sender, EventArgs e)
        {
            if (NeueRunde != null)
            {
                NeueRunde(_Runde, null);
            }
        }

        public void DieseRundeLoeschen(object sender, EventArgs e)
        {
            if (RundeLoeschen != null)
            {
                RundeLoeschen(_Runde, null);
            }
        }
    }
}
