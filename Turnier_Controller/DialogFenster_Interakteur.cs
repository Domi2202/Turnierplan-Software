using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Turnierplan_Software;
using Turnierklassen;

namespace Turnier_Controller
{
    abstract class DialogFenster_Interakteur<T> where T : new()
    {
        protected Dialog_Objektdetails _Dialogfenster;
        protected List<DialogFeld> _Dialogfelder;
        protected T _AnzulegendesObjekt;
        protected EventHandler _ObjektAngelegt;

        public DialogFenster_Interakteur(EventHandler on_objekt_angelegt)
        {
            _AnzulegendesObjekt = new T();
            _Dialogfenster = new Dialog_Objektdetails();
            _Dialogfelder = new List<DialogFeld>();
            _Dialogfenster.Input_Submitted += On_InputSubmitted;
            _Dialogfenster.Input_Canceled += On_InputCanceled;
            _Dialogfenster.Title = Titel_ausgeben();
            _ObjektAngelegt += on_objekt_angelegt;
            Dialogfelder_erstellen();
            Dialog_aufbauen();
            _Dialogfenster.Show();
        }

        protected abstract string Titel_ausgeben();

        protected abstract void Dialogfelder_erstellen();

        protected abstract void Objekt_anlegen();

        protected abstract void Objekt_speichern();

        private void On_InputSubmitted(object sender, EventArgs e)
        {
            try
            {
                Objekt_anlegen();
                Objekt_speichern();
                if(_ObjektAngelegt != null)
                {
                    _ObjektAngelegt(this, null);
                }
                _Dialogfenster.Close();
            }
            catch (Exception exc)
            {
                new FehlerFenster(exc.Message).Show();
            }
        }

        private void On_InputCanceled(object sender, EventArgs e)
        {
            _Dialogfenster.Close();
        }

        private void Dialog_aufbauen()
        {
            foreach (DialogFeld feld in _Dialogfelder)
            {
                NewDialogField(feld);
            }
        }

        private void NewDialogField(DialogFeld feld)
        {
            _Dialogfenster.Panel_Keys.Add(feld.Feld_Name);
            _Dialogfenster.Panel_Values.Add(feld.Feld_Inhalt);
            _Dialogfenster.ResizeWindowHeight(feld.Feld_Name.Height);
        }

        protected void Feldwerte_pruefen()
        {
            foreach (DialogFeld feld in _Dialogfelder)
            {
                if (feld.Get_Inhalt() == string.Empty)
                {
                    throw new InvalidInputException("Bitte alle Felder ausfüllen!\nDie Eingaben können später noch geändert werden!");
                }
            }
        }
    }

   
}
