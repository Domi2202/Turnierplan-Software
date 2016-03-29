using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnierklassen;
using Turnier_Prefabs;

namespace Turnier_Controller
{
    public class VeranstaltungsErsteller
    {
        public static List<DialogFeld> Dialog_bereitstellen() 
        {
            List<DialogFeld> dialog_felder = new List<DialogFeld>();
            dialog_felder.Add(new DialogFeld_Text("Name der Veranstaltung"));
            dialog_felder.Add(new DialogFeld_Checkbox("Test"));
            dialog_felder.Add(new DialogFeld_Text("Name der Veranstaltung"));
            dialog_felder.Add(new DialogFeld_Text("Name der Veranstaltung"));
            dialog_felder.Add(new DialogFeld_Checkbox("Test"));
            dialog_felder.Add(new DialogFeld_Text("Name der Veranstaltung"));

            return dialog_felder;
        }

        //Eingabe entgegennehmen

        //Objekt speichern
    }
}
