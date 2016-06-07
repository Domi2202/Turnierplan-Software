using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnierklassen;
using Turnierplan_Software;
using System.Windows;
using System.ComponentModel;

namespace Turnier_Controller
{
    class Spieltagbox_Interakteur : INotifyPropertyChanged
    {
        private Spieltag _Spieltag;
        private SpieltagBox _Box;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public SpieltagBox SpieltagBox
        {
            get { return _Box; }
        }

        public Spieltagbox_Interakteur(Spieltag spieltag)
        {
            _Spieltag = spieltag;
            _Box = new SpieltagBox();
            _Box.DataContext = this;
        }

        #region BindingProperties

        /// <summary>
        /// Gets and sets the date for the connected tournament day
        /// </summary>
        public DateTime Datum
        {
            get { return _Spieltag.Startzeit; }
            set 
            {
                _Spieltag.DatumSetzen(value);
            }
        }
        /// <summary>
        /// Gets or sets the starting hour for the tournament day
        /// </summary>
        public int Startzeit_Stunde
        {
            get { return _Spieltag.Startzeit.Hour; }
            set
            {
                _Spieltag.Startzeit_Stunde_setzen(value);
            }
        }
        public int Startzeit_Minute
        {
            get { return _Spieltag.Startzeit.Minute; }
            set
            {
                _Spieltag.Startzeit_Minute_setzen(value);
            }
        }
        public int Endzeit_Stunde
        {
            get { return _Spieltag.Endezeit.Hour; }
            set
            {
                _Spieltag.Endezeit_Stunde_setzen(value);
            }
        }
        public int Endzeit_Minute
        {
            get { return _Spieltag.Endezeit.Minute; }
            set
            {
                _Spieltag.Endezeit_Minute_setzen(value);
            }
        }

        public string Name
        {
            get { return _Spieltag.Name; }
        }

        #endregion
    }
}
