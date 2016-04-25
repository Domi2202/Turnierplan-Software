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
        public EventHandler Speichern { get; set; }
        public EventHandler Laden { get; set; }
        public CancelEventHandler ProgrammBeenden { get; set; }
        public Label Label_Veranstaltung { get; set; }
        public Grid Grid_Informationen { get; set; }
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
            Grid_Informationen = grid_informationen;
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
    }
}
