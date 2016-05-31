using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Endrunde 
    {
        private Modus _Modus;
        private bool _kleinesFinale;

        /// <summary>
        /// Gets or sets the selected mode for the final round
        /// </summary>
        public Modus Modus
        {
            get { return _Modus; }
            set
            {
                _Modus = value;
                UnsetThirdPlacePlayoffIfNecessary();
                Datei_Interakteur.Save_Temp();
            }
        }
        /// <summary>
        /// Gets or sets wether a third-place-playoff is played in the final round
        /// </summary>
        public bool Kleines_Finale
        {
            get { return _kleinesFinale; }
            set
            {
                _kleinesFinale = value;
                Datei_Interakteur.Save_Temp();
            }
        }
        public List<Teilnahmerregel> Teilnahmeregeln { get; set; }
        public List<Runde> Runden { get; set; }

        public Endrunde()
        {
            Teilnahmeregeln = new List<Teilnahmerregel>();
            Runden = new List<Runde>();
            Modus = Modus.Keiner;
        }

        #region privateFunctions

        private void UnsetThirdPlacePlayoffIfNecessary()
        {
            if (Modus == Modus.Finale)
            {
                _kleinesFinale = false;
            }
        }

        #endregion

        #region publicFunctions

        public void AddNewParticipationRule(Teilnahmerregel rule)
        {
            Teilnahmerregel newRule = new Teilnahmerregel();
            foreach (Kandidat kandidat in rule.CriteriaList)
            {
                newRule.AddCriteria(kandidat.Group, kandidat.Rank);
            }
            newRule.Name = rule.Name;
            Teilnahmeregeln.Add(newRule);
            Datei_Interakteur.Save_Temp();
        }

        public void DeleteParticipationRule(int index)
        {
            Teilnahmeregeln.Remove(Teilnahmeregeln.ElementAt(index));
            Datei_Interakteur.Save_Temp();
        }

        public void RundenErzeugen()
        {
            Runden.Clear();
            for (int i = (int)Modus; i > 1; i = i/2)
            {
                Runde runde = new Runde(i / 2);
                Runden.Add(runde);
            }
            Datei_Interakteur.Save_Temp();
        }

        #endregion
    }

    public class Runde
    {
        public int ID { get; set; }
        public int Anzahl_Paarungen { get; set; }
        public List<Paarung> Paarungen { get; set; }

        public Runde(int anzahl_paarungen)
        {
            Paarungen = new List<Paarung>();
            Anzahl_Paarungen = anzahl_paarungen;
            PaarungenErzeugen();
        }

        private void PaarungenErzeugen()
        {
            for(int i = 0; i < Anzahl_Paarungen; i++)
            {
                Paarungen.Add(new Paarung());
            }
        }
    }

    public enum Modus { Keiner = 0, Finale = 2, Halbfinale = 4, Viertelfinale = 8, Achtelfinale = 16, Sechzehntelfinale = 32 }
}
