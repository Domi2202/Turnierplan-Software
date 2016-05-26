using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Trostrunde
    {
        private Gruppe _jederGegenJeden;
        private Endrunde _playoffs;
        public Gruppe JederGegenJeden
        {
            get { return _jederGegenJeden; }
            set
            {
                _jederGegenJeden = value;
                _playoffs = null;
                Datei_Interakteur.Save_Temp();
            }
        }
        public Endrunde Playoffs
        {
            get { return _playoffs; }
            set
            {
                _playoffs = value;
                _jederGegenJeden = null;
                Datei_Interakteur.Save_Temp();
            }
        }

        public void JederGegenJeden_setztenOderZerstören(int teilnehmer)
        {
            if (_jederGegenJeden == null)
            {
                JederGegenJeden = new Gruppe("Trostrunde", teilnehmer);
            }
            else
            {
                _jederGegenJeden = null;
                Datei_Interakteur.Save_Temp();
            }
        }

        public void Playoffs_setztenOderZerstören()
        {
            if (_playoffs == null)
            {
                Playoffs = new Endrunde();
            }
            else
            {
                _playoffs = null;
                Datei_Interakteur.Save_Temp();
            }
        }

        public int AnzahlSpieleBerechnen()
        {
            if (_playoffs != null)
            {
                return (int)_playoffs.Modus;
            }
            else if (_jederGegenJeden != null)
            {
                return _jederGegenJeden.AnzahlSpieleBerechnen();
            }
            else return 0;
        }
    }
}
