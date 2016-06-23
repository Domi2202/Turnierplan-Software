using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Runde
    {
        public string Name { get; set; }
        public Guid ID { get; set; }
        public List<Paarung> Paarungen { get; set; }
        public bool Siegerrunde { get; set; }
        public Guid Vorgaenerrunde { get; set; }

        public Runde() { }

        public Runde(int anzahl_paarungen)
        {
            Paarungen = new List<Paarung>();
            PaarungenErzeugen(anzahl_paarungen);
            ID = Guid.NewGuid();
        }

        public void NamenSetzen(string name)
        {
            Name = name;
            PaarungenBenennen();
        }

        private void PaarungenErzeugen(int anzahl_paarungen)
        {
            for (int i = 0; i < anzahl_paarungen; i++)
            {
                Paarungen.Add(new Paarung());
            }
        }

        private void PaarungenBenennen()
        {
            int n = 1;
            foreach (Paarung paarung in Paarungen)
            {
                paarung.Name = Name + " " + Convert.ToString(n);
                n++;
            }
        }

        public int GetSpielezahl()
        {
            return Paarungen.Count;
        }

        public void SetSiegerrunde(bool val)
        {
            Siegerrunde = val;
            Datei_Interakteur.Save_Temp();
        }

        public void SetVorgaengerRunde(Guid id)
        {
            Vorgaenerrunde = id;
            Datei_Interakteur.Save_Temp();
        }

        public Paarung GetMatchByID(Guid id)
        {
            foreach (Paarung paarung in Paarungen)
            {
                if (paarung.ID == id)
                {
                    return paarung;
                }
            }
            throw new KeyNotFoundException("Diese Paarung ist kein Teil dieser Runde");
        }

        public void SpieleBelegen(Runde vorgaenger)
        {
            for (int i = 0; i < Paarungen.Count; i++)
            {
                Paarungen.ElementAt(i).QualifikationsSpielSetzen_TeamA(new Qualifikationsspiel(vorgaenger.Paarungen.ElementAt(i * 2).Name, Siegerrunde));
                Paarungen.ElementAt(i).QualifikationsSpielSetzen_TeamB(new Qualifikationsspiel(vorgaenger.Paarungen.ElementAt(i * 2 + 1).Name, Siegerrunde));
            }
        }
    }
}
