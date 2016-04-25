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
        private Turnier _Turnier;
        protected override string Titel_ausgeben()
        {
            return "Mannschaft hinzufügen";
        }

        public DialogFensterMannschaft_Interakteur(Turnier turnier) : base()
        {
            _Turnier = turnier;
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
            Turnier turnier = Datei_Interakteur.Geladene_Veranstaltung.Turniere.Find(x => x.Name == _Turnier.Name);
            turnier.Mannschaften.Add(new Mannschaft());
            turnier.Mannschaften.Last().Name = _AnzulegendesObjekt.Name;
            turnier.Mannschaften.Last().Ist_aus_Bayern = _AnzulegendesObjekt.Ist_aus_Bayern;
            turnier.Mannschaften.Last().Ist_Spaetstarter = _AnzulegendesObjekt.Ist_Spaetstarter;
            Datei_Interakteur.Save_Temp();
        }
    }
}
