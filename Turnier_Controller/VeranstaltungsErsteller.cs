using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
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
            Dialog_Felder.Add(new DialogFeld_Zahl("Anzahl bespielter Felder"));

            return Dialog_Felder;
        }

        public override void Anfrage_entgegennehmen()
        {
            Veranstaltung neue_Veranstaltung = new Veranstaltung();
            try
            {
                neue_Veranstaltung.Name = Suche_Feld("Name der Veranstaltung").Get_Inhalt();
                neue_Veranstaltung.Anzahl_Spielfelder = Convert.ToInt32(Suche_Feld("Anzahl bespielter Felder").Get_Inhalt());
            }
            catch
            {
                Debug.Write("Fehlerhaft ausgefüllt");
            }
            Debug.WriteLine(neue_Veranstaltung.Name);
            Debug.WriteLine(neue_Veranstaltung.Anzahl_Spielfelder);
        }

        //Objekt speichern
    }
}
