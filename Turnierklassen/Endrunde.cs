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
        private bool _loserBracket;

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
                if (value == false) _loserBracket = false;
                Datei_Interakteur.Save_Temp();
            }
        }
        /// <summary>
        /// Gets or sets wether a loser round is played
        /// </summary>
        public bool Loser_Bracket
        {
            get { return _loserBracket; }
            set
            {
                _loserBracket = value;
                if (value == true) _kleinesFinale = true;
                Datei_Interakteur.Save_Temp();
            }
        }
        public List<Teilnahmerregel> Teilnahmeregeln { get; set; }
        public List<Runde> Runden { get; set; }
        public List<Runde> Verliererrunde { get; set; }

        public Endrunde()
        {
            Teilnahmeregeln = new List<Teilnahmerregel>();
            Runden = new List<Runde>();
            Verliererrunde = new List<Runde>();
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

        public void DeleteParticipationRule(Teilnahmerregel regel)
        {
            Teilnahmeregeln.Remove(regel);
            Datei_Interakteur.Save_Temp();
        }

        public void StartrundeAnlegen()
        {
            Runden.Clear();
            Runde startrunde = new Runde((int)_Modus / 2);
            startrunde.NamenSetzen(_Modus.ToString());
            startrunde.Siegerrunde = true;
            Runden.Add(startrunde);
            Datei_Interakteur.Save_Temp();
        }

        public void RundeHinzufuegen(Runde vorgaenger)
        {
            if (vorgaenger.Paarungen.Count == 1) return;
            Runde neueRunde = new Runde(vorgaenger.Paarungen.Count / 2);
            neueRunde.Vorgaenerrunde = vorgaenger.ID;
            neueRunde.Siegerrunde = true;
            Modus neu = (Modus)(neueRunde.Paarungen.Count * 2);
            neueRunde.NamenSetzen(neu.ToString());
            neueRunde.SpieleBelegen(vorgaenger);
            Runden.Add(neueRunde);
            Datei_Interakteur.Save_Temp();
        }

        /// <summary>
        /// Deletes the specified round and unsets it as a predecessor for other rounds if necessary
        /// </summary>
        /// <param name="zuLoeschendeRunde"></param>
        public void RundeLoeschen(Runde zuLoeschendeRunde)
        {
            Runden.Remove(zuLoeschendeRunde);
            foreach (Runde runde in Runden)
            {
                if (runde.Vorgaenerrunde == zuLoeschendeRunde.ID)
                {
                    runde.Vorgaenerrunde = Guid.Empty;
                }
            }
            Datei_Interakteur.Save_Temp();
        }

        /// <summary>
        /// Returns the round object with the submitted id or throws key not found exception
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Runde RundeMitID(Guid id) 
        {
            foreach(Runde runde in Runden)
            {
                if (runde.ID == id)
                {
                    return runde;
                }
            }
            throw new KeyNotFoundException("Die keine Runde mit dieser ID wurde gefunden");
        }

        //public void VerliererrundenErzeugen()
        //{
        //    Verliererrunde.Clear();
        //    for (int i = (int)Modus / 2; i > 1; i = i / 2)
        //    {
        //        Runde runde = new Runde(i / 2);
        //        Verliererrunde.Add(runde);
        //    }
        //    Datei_Interakteur.Save_Temp();
        //}

        public int SpielezahlBerechnen()
        {
            int games = 0;
            int teams = (int)Modus;
            while (teams > 1)
            {
                games += teams / 2;
                teams = teams / 2;
            }
            if (Kleines_Finale) games += 1;
            return games;
        }

        #endregion
    }

    public enum Modus { Keiner = 0, Finale = 2, Halbfinale = 4, Viertelfinale = 8, Achtelfinale = 16, Sechzehntelfinale = 32 }
}
