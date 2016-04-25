using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnierplan_Software;

namespace Turnier_Controller
{
    internal class Veranstaltungsmanager_Interakteur
    {
        private Veranstaltunsmanager _Fenster;
        private Listenelement<string> _Markierte_Veranstaltung;

        public Veranstaltungsmanager_Interakteur() 
        {
            _Fenster = new Veranstaltunsmanager();
            _Fenster.Laden += On_Laden;
            _Fenster.Loeschen += On_Loeschen;
            _Fenster.Neu += On_Neu;
            Veranstaltungen_zeigen();
            _Fenster.Show();
        }

        private void Veranstaltungen_zeigen()
        {
            List<string> gespeicherte_Veranstaltungen = Datei_Interakteur.Speicherordner_scannen();
            foreach (string veranstaltung in gespeicherte_Veranstaltungen)
            {
                _Fenster.Veranstaltungen.Items.Add(new Listenelement<string>(veranstaltung, veranstaltung));
            }
        }

        private void On_Laden(object sender, EventArgs e)
        {
            if(_Fenster.Veranstaltungen.SelectedItem != null)
            {
                if (!Datei_Interakteur.All_Saved)
                {
                    new AnfrageFenster_Speichern(Laden);
                }
                else Laden(this, null);
            }
        }

        private void Laden(object sender, EventArgs e)
        {
            _Markierte_Veranstaltung = _Fenster.Veranstaltungen.SelectedItem as Listenelement<string>;
            Datei_Interakteur.File_Name = _Markierte_Veranstaltung.Details;
            Datei_Interakteur.Load();
            _Fenster.Close();
        }

        private void On_Loeschen(object sender, EventArgs e)
        {
            if (_Fenster.Veranstaltungen.SelectedItem != null)
            {
                _Markierte_Veranstaltung = _Fenster.Veranstaltungen.SelectedItem as Listenelement<string>;
                Datei_Interakteur.Delete(_Markierte_Veranstaltung.Details);
                Ansicht_bereinigen();
                Veranstaltungen_zeigen();
            } 
        }

        private void On_Neu(object sender, EventArgs e)
        {
            if (!Datei_Interakteur.All_Saved)
            {
                new AnfrageFenster_Speichern(Neue_Veranstaltung);
            }
            else Neue_Veranstaltung(this, null);
        }

        private void Neue_Veranstaltung(object sender, EventArgs e)
        {
            new DialogFensterVeranstaltung_Interakteur();
            _Fenster.Close();
        }

        private void Ansicht_bereinigen()
        {
            _Fenster.Veranstaltungen.Items.Clear();
        }
    }
}
