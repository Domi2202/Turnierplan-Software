using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnierklassen;
using Turnierplan_Software;

namespace Turnier_Controller
{
    class DialogFensterTurnier_Interakteur : DialogFenster_Interakteur<Turnier>
    {
        public DialogFensterTurnier_Interakteur(EventHandler On_Turnier_hinzugefügt) : base (On_Turnier_hinzugefügt) { } 

        protected override string Titel_ausgeben()
        {
            return "Turnier erstellen";
        }

        protected override void Dialogfelder_erstellen()
        {
            _Dialogfelder.Add(new DialogFeld_Text("Name des Turniers"));
        }

        protected override void Objekt_anlegen()
        {
            base.Objekt_anlegen();
            try
            {
                _AnzulegendesObjekt.Name = _Dialogfelder.ElementAt(0).Get_Inhalt();
            }
            catch
            {
                throw new InvalidInputException("Bei der Verarbeitung der Daten ist ein Fehler aufgetreten!\nBitte prüfen Sie ob alle Felder korrekt ausgefüllt sind!");
            }
        }

        protected override void Objekt_speichern()
        {
            if (Datei_Interakteur.Geladene_Veranstaltung == null)
            {
                throw new InvalidOperationException("Es muss eine Veranstaltung erstellt werden, bevor Turniere hinzugefügt werden können!");
            }
            if (Datei_Interakteur.Name_verfügbar(_AnzulegendesObjekt))
            {
                Datei_Interakteur.Geladene_Veranstaltung.Turniere.Add(new Turnier());
                Datei_Interakteur.Geladene_Veranstaltung.Turniere.Last().Name = _AnzulegendesObjekt.Name;
                Datei_Interakteur.Save_Temp();
            }
            else throw new DuplicateIdentifierException("Das Turnier " + _AnzulegendesObjekt.Name + " existiert in " + Datei_Interakteur.Geladene_Veranstaltung.Name + " bereits!");
        }
    }
}
