using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Paarung
    {
        public Teilnahmerregel Regel_Mannschaft_A { get; set; }
        public Teilnahmerregel Regel_Mannschaft_B { get; set; }
        public Qualifikationsspiel Vorheriges_Spiel_A { get; set; }
        public Qualifikationsspiel Vorheriges_Spiel_B { get; set; }
        public string Mannschaft_A { get; set; }
        public string Mannschaft_B { get; set; }
        public string Name { get; set; }
        public string Turnier { get; set; }
        public List<Halbzeitergebnis> Halbzeitergebnisse { get; set; }

        public Paarung()
        {
            Halbzeitergebnisse = new List<Halbzeitergebnis>();
        }

        public string Name_MannschaftA()
        {
            if (Mannschaft_A != null)
            {
                return Mannschaft_A;
            }
            else if (Vorheriges_Spiel_A != null)
            {
                return Vorheriges_Spiel_A.Titel();
            }
            else if (Regel_Mannschaft_A != null)
            {
                return Regel_Mannschaft_A.Name;
            }
            else return "Team A";
        }

        public string Name_MannschaftB()
        {
            if (Mannschaft_B != null)
            {
                return Mannschaft_B;
            }
            else if (Vorheriges_Spiel_B != null)
            {
                return Vorheriges_Spiel_B.Titel();
            }
            else if (Regel_Mannschaft_B != null)
            {
                return Regel_Mannschaft_B.Name;
            }
            else return "Team B";

        }

        public string Sieger()
        {
            return "Sieger " + Name;
        }

        public void QualifikationsSpielSetzen_TeamA(Qualifikationsspiel quali)
        {
            Vorheriges_Spiel_A = new Qualifikationsspiel(quali.Name, quali.Gewinner);
            Datei_Interakteur.Save_Temp();
        }

        public void QualifikationsSpielSetzen_TeamB(Qualifikationsspiel quali)
        {
            Vorheriges_Spiel_B = new Qualifikationsspiel(quali.Name, quali.Gewinner);
            Datei_Interakteur.Save_Temp();
        }
    }

    public class Halbzeitergebnis
    {
        public int Tore_A { get; set; }
        public int Tore_B { get; set; }
    }
}
