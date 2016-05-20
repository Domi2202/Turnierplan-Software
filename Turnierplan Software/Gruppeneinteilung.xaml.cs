using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Turnierplan_Software
{
    /// <summary>
    /// Interaktionslogik für Gruppeneinteilung.xaml
    /// </summary>
    public partial class Gruppeneinteilung : UserControl
    {

        public Label Label_Turniername { get; set; }
        public ComboBox Anzahl_Gruppen { get; set; }
        public Label Label_Zahl { get; set; }
        public Label Label_Poolzahl { get; set; }
        public ListBox Listbox_Pool { get; set; }
        public EventHandler Btn_Zuteilen { get; set; }
        public EventHandler Btn_Ausleeren { get; set; }
        public EventHandler Btn_Bestätigen { get; set; }
        public EventHandler Btn_Rechts { get; set; }
        public EventHandler Btn_Links { get; set; }
        public Grid Grid_Gruppenboxen { get; set; }
        public TextBox Gruppen_von { get; set; }
        public TextBox Gruppen_bis { get; set; }
        public Grid Warnung_teilnehmer_entfernt { get; set; }
        public EventHandler Gruppengrenzen_aktualisiert { get; set; }

        private void XamlElemente_zuordnen()
        {
            Label_Turniername = label_turniername;
            Anzahl_Gruppen = Combobox_anzahlGruppen;
            Label_Zahl = label_zahl;
            Label_Poolzahl = label_poolzahl;
            Listbox_Pool = listbox_pool;
            Grid_Gruppenboxen = grid_gruppenboxen;
            Gruppen_von = textbox_gruppenVon;
            Gruppen_bis = textbox_gruppenBis;
            Warnung_teilnehmer_entfernt = grid_teilnehmerzahl_verringert;
        }
        public Gruppeneinteilung()
        {
            InitializeComponent();
            XamlElemente_zuordnen();
        }

        private void btn_zuteilen_Click(object sender, RoutedEventArgs e)
        {
            if (Btn_Zuteilen != null)
            {
                Btn_Zuteilen(this, null);
            }
        }

        private void btn_ausleeren_Click(object sender, RoutedEventArgs e)
        {
            if (Btn_Ausleeren != null)
            {
                Btn_Ausleeren(this, null);
            }
        }

        private void btn_bestätigen_Click(object sender, RoutedEventArgs e)
        {
            if (Btn_Bestätigen != null)
            {
                Btn_Bestätigen(this, null);
            }
        }

        private void btn_rechts_Click(object sender, RoutedEventArgs e)
        {
            if (Btn_Rechts != null)
            {
                Btn_Rechts(this, null);
            }
        }

        private void btn_links_Click(object sender, RoutedEventArgs e)
        {
            if (Btn_Links != null)
            {
                Btn_Links(this, null);
            }
        }

        private void textbox_gruppenVon_ManipulationCompleted(object sender, TextChangedEventArgs e)
        {
            if (Gruppengrenzen_aktualisiert != null)
            {
                Gruppengrenzen_aktualisiert(this, null);
            }
        }


    }
}
