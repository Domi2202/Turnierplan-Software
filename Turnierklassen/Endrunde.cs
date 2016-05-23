using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Endrunde : INotifyPropertyChanged
    {
        private Modus _Modus;

        public int Anzahl_Teilnehmer { get { return (int)Modus; } }
        public Modus Modus
        {
            get { return _Modus; }
            set
            {
                _Modus = value;
                NotifyPropertyChanged("Anzahl_Teilnehmer");
            }
        }
        public List<Runde> Runden { get; set; }
        public bool Mit_kleinem_Finale { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
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
