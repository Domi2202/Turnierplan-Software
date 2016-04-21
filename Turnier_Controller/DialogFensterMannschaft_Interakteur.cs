using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnierklassen;
using Turnierplan_Software;

namespace Turnier_Controller
{
    class DialogFensterMannschaft_Interakteur : DialogFenster_Interakteur<Mannschaft>
    {
        protected override string Titel_ausgeben()
        {
            return "Mannschaft hinzufügen";
        }

        protected override void Dialogfelder_erstellen()
        {
            _Dialogfelder.Add(new DialogFeld_Text("Name der Mannschaft"));
            _Dialogfelder.Add(new DialogFeld_Checkbox("Aus Bayern"));
            _Dialogfelder.Add(new DialogFeld_Checkbox("Spätstarter"));
        }

        protected override void Objekt_anlegen()
        {
            Feldwerte_pruefen();
            try
            {
                _AnzulegendesObjekt.Name = _Dialogfelder.ElementAt(0).Get_Inhalt();
                _AnzulegendesObjekt.Ist_aus_Bayern = Convert.ToBoolean(_Dialogfelder.ElementAt(1).Get_Inhalt());
                _AnzulegendesObjekt.Ist_Spaetstarter = Convert.ToBoolean(_Dialogfelder.ElementAt(2).Get_Inhalt());
            }
            catch
            {
                throw new InvalidInputException("Bei der Verarbeitung der Daten ist ein Fehler aufgetreten!\nBitte prüfen Sie ob alle Felder korrekt ausgefüllt sind!");
            }
        }

        protected override void Objekt_speichern()
        {
            /*Datei_Interakteur.Geladene_Veranstaltung.Turniere
            Datei_Interakteur.Path = "C:\\Users\\Dominik\\Desktop\\testytest.tps"; //gaaaanz gaaaaaaaaaanz schlecht SOOOOO SCHLECHT, MACHT DAS BLOSS NICHT SO!!!!!!!!
            Datei_Interakteur.Save_Temp();*/
        }
    }
}
