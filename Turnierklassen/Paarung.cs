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
        public string Vorheriges_Spiel_A { get; set; }
        public string Vorheriges_Spiel_B { get; set; }
        public string Mannschaft_A { get; set; }
        public string Mannschaft_B { get; set; }
        public string Name { get; set; }
        public string Turnier { get; set; }
        public List<Halbzeitergebnis> Halbzeitergebnisse { get; set; }

        public Paarung()
        {
            Halbzeitergebnisse = new List<Halbzeitergebnis>();
        }

        public string Name_MannschaftA
        {
            get
            {
                if (Mannschaft_A != null)
                {
                    return Mannschaft_A;
                }
                else if (Vorheriges_Spiel_A != null)
                {
                    return Vorheriges_Spiel_A;
                }
                else if (Regel_Mannschaft_A != null)
                {
                    return Regel_Mannschaft_A.Name;
                }
                else return "Team A";
            }
        }

        public string Name_MannschaftB
        {
            get
            {
                if (Mannschaft_B != null)
                {
                    return Mannschaft_B;
                }
                else if (Vorheriges_Spiel_B != null)
                {
                    return Vorheriges_Spiel_B;
                }
                else if (Regel_Mannschaft_B != null)
                {
                    return Regel_Mannschaft_B.Name;
                }
                else return "Team B";
            }
        }

        public string Sieger()
        {
            return "Sieger " + Name;
        }
    }

    public class Halbzeitergebnis
    {
        public int Tore_A { get; set; }
        public int Tore_B { get; set; }
    }
}
