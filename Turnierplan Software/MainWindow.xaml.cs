using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public EventHandler TurnierHinzufuegen { get; set; }
        public EventHandler TurnierLoeschen { get; set; }
        public EventHandler Speichern { get; set; }
        public EventHandler Laden { get; set; }
        public EventHandler Veranstaltungsuebersicht { get; set; }
        public CancelEventHandler ProgrammBeenden { get; set; }
        public TabControl Turnierdetails { get; set; }
        public Label Label_Veranstaltung { get; set; }
        public Grid Grid_Mannschaften { get; set; }
        public Grid Grid_Veranstaltungsuebersicht { get; set; }
        public Grid Grid_Gruppeneinteilung { get; set; }
        public Grid Grid_Endrunde { get; set; }
        public Grid Grid_Uebersicht { get; set; }
        public ListBox Turnierliste { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            XamlElemente_zuordnen();
        }

        private void XamlElemente_zuordnen()
        {
            Label_Veranstaltung = label_veranstaltung;
            Turnierliste = listbox_turniere;
            Grid_Mannschaften = grid_mannschaften;
            Grid_Gruppeneinteilung = grid_gruppeneinteilung;
            Grid_Endrunde = grid_endrunde;
            Grid_Uebersicht = grid_uebersicht;
            Grid_Veranstaltungsuebersicht = grid_veranstaltungsuebersicht;
            Turnierdetails = tabControl_turnier;


        }

        private void button_turnier_hinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            if (TurnierHinzufuegen != null)
            {
                TurnierHinzufuegen(this, null);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (ProgrammBeenden != null)
            {
                ProgrammBeenden(this, e);
            }  
        }

        private void button_speichern_Click(object sender, RoutedEventArgs e)
        {
            if (Speichern != null)
            {
                Speichern(this, null);
            }
        }

        private void button_laden_Click(object sender, RoutedEventArgs e)
        {
            if (Laden != null)
            {
                Laden(this, null);
            }
        }

        private void button_crash_Click(object sender, RoutedEventArgs e)
        {
            throw new Exception();
        }

        private void button_turnier_loeschen_Click(object sender, RoutedEventArgs e)
        {
            if (TurnierLoeschen != null)
            {
                TurnierLoeschen(this, null);
            }
        }

        private void button_veranstaltungsuebersicht_Click(object sender, RoutedEventArgs e)
        {
            if (Veranstaltungsuebersicht != null)
            {
                Veranstaltungsuebersicht(this, null);
            }
        }
    }
}
