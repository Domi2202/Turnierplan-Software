using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Turnierklassen;
using Turnierplan_Software;

namespace Turnier_Controller
{
    class DialogFensterVeranstaltung_Interakteur : DialogFenster_Interakteur<Veranstaltung>
    {
        protected override string Titel_ausgeben()
        {
            return "Veranstaltung erstellen";
        }

        protected override void Dialogfelder_erstellen()
        {
            _Dialogfelder.Add(new DialogFeld_Text("Name der Veranstaltung"));
            _Dialogfelder.Add(new DialogFeld_Zahl("Bespielte Felder"));
        }

        protected override void Objekt_anlegen()
        {
            Feldwerte_pruefen();
            try
            {
                _AnzulegendesObjekt.Name = _Dialogfelder.ElementAt(0).Get_Inhalt();
                _AnzulegendesObjekt.Anzahl_Spielfelder = Convert.ToInt32(_Dialogfelder.ElementAt(1).Get_Inhalt());
            }
            catch
            {
                throw new InvalidInputException("Bei der Verarbeitung der Daten ist ein Fehler aufgetreten!\nBitte prüfen Sie ob alle Felder korrekt ausgefüllt sind!");
            }
        }

        protected override void Objekt_speichern()
        {
            Datei_Interakteur.Geladene_Veranstaltung = new Veranstaltung();
            Datei_Interakteur.Geladene_Veranstaltung.Name = _AnzulegendesObjekt.Name;
            Datei_Interakteur.Geladene_Veranstaltung.Anzahl_Spielfelder = _AnzulegendesObjekt.Anzahl_Spielfelder;
            Datei_Interakteur.File_Name = _AnzulegendesObjekt.Name;
            Datei_Interakteur.Save_Temp();
        }
    }
}
