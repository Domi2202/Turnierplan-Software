using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnierplan_Software;

namespace Turnier_Controller
{
    internal class LadeFenster_Interakteur
    {
        private LadeFenster _Fenster;
        private Listenelement<string> _Markierte_Veranstaltung;

        public LadeFenster_Interakteur() 
        {
            _Fenster = new LadeFenster();
            _Fenster.Laden += On_Laden;
            _Fenster.Loeschen += On_Loeschen;
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
            _Markierte_Veranstaltung = _Fenster.Veranstaltungen.SelectedItem as Listenelement<string>;
            Datei_Interakteur.File_Name = _Markierte_Veranstaltung.Details;
            Datei_Interakteur.Load();
            _Fenster.Close();
        }

        private void On_Loeschen(object sender, EventArgs e)
        {
            _Markierte_Veranstaltung = _Fenster.Veranstaltungen.SelectedItem as Listenelement<string>;
            Datei_Interakteur.Delete(_Markierte_Veranstaltung.Details);
            Ansicht_bereinigen();
            Veranstaltungen_zeigen();
        }

        private void Ansicht_bereinigen()
        {
            _Fenster.Veranstaltungen.Items.Clear();
        }
    }
}
