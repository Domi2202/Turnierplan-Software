using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Trostrunde
    {
        private bool _gruppeAktiv;
        private bool _endrundeAktiv;
        private int _teilnehmerAnzahl;
        private Gruppe _jederGegenJeden;
        private Endrunde _playoffs;

        #region PublicProperties

        public bool JederGegenJeden_Aktiv
        {
            get { return _gruppeAktiv; }
            set
            {
                _gruppeAktiv = value;
                if (value == true)
                {
                    _endrundeAktiv = false;
                }
                Datei_Interakteur.Save_Temp();
            }
        }

        public bool Playoffs_aktiv
        {
            get { return _endrundeAktiv; }
            set
            {
                _endrundeAktiv = value;
                if (value == true)
                {
                    _gruppeAktiv = false;
                }
                Datei_Interakteur.Save_Temp();
            }
        }

        public int Teilnehmerzahl
        {
            get { return _teilnehmerAnzahl; }
            set
            {
                _teilnehmerAnzahl = value;
                _jederGegenJeden.Anzahl_Teilnehmer = value;
                Datei_Interakteur.Save_Temp();
            }
        }

        public Endrunde Playoffs
        {
            get { return _playoffs; }
        }

        public Gruppe JederGegenJeden
        {
            get { return _jederGegenJeden; }
        }

        #endregion

        #region PublicConstructors

        public Trostrunde()
        {
            _jederGegenJeden = new Gruppe();
            _playoffs = new Endrunde();
        }

        #endregion

        #region PublicFunctions

        public int AnzahlSpieleBerechnen()
        {
            if (_endrundeAktiv)
            {
                return (int)_playoffs.Modus;
            }
            else if (_gruppeAktiv)
            {
                return _jederGegenJeden.AnzahlSpieleBerechnen();
            }
            else return 0;
        }

        #endregion
    }
}
