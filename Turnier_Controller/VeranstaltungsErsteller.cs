using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnierklassen;
using Turnier_Prefabs;

namespace Turnier_Controller
{
    public class VeranstaltungsErsteller : ObjektErsteller
    {
        public VeranstaltungsErsteller()
        {
            Dialogtyp = "Veranstaltung erstellen";
        }
        public override List<DialogFeld> Dialogfelder_bereitstellen() 
        {
            Dialog_Felder.Add(new DialogFeld_Text("Name der Veranstaltung"));
            Dialog_Felder.Add(new DialogFeld_Checkbox("Test"));
            Dialog_Felder.Add(new Dialogfeld_Zahl("Bespielte Felder"));

            return Dialog_Felder;
        }

        //Eingabe entgegennehmen

        //Objekt speichern
    }
}
