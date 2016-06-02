using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Qualifikationsspiel
    {
        public string Name { get; set; }
        public bool Gewinner { get; set; }

        public Qualifikationsspiel()
        {
            Name = string.Empty;
            Gewinner = true;
        }

        public Qualifikationsspiel(string name, bool gewinner)
        {
            Name = name;
            Gewinner = gewinner;
        }

        public Qualifikationsspiel(Paarung paarung, bool gewinner)
        {
            Name = paarung.Name;
            Gewinner = gewinner;
        }

        public string Titel()
        {
            if (Gewinner) return "Sieger " + Name;
            else return "Verlierer " + Name;
        }
    }
}
