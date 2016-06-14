using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using Turnierklassen;
using Turnierplan_Software;

namespace Turnier_Controller
{
    class Rundenbox_Interakteur : INotifyPropertyChanged
    {
        private Runde _Runde;
        private RundenBox _Box;

        public EventHandler NeueRunde { get; set; }

        public RundenBox Box
        {
            get { return _Box; }
        }

        public Rundenbox_Interakteur(Runde runde)
        {
            _Runde = runde;
            _Box = new RundenBox();
            _Box.DataContext = this;
            _Box.Nachfolgerrunde = NeueRundeHinzufuegen;
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
            set { _Runde.SetSiegerrunde(value); }
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
    }
}
