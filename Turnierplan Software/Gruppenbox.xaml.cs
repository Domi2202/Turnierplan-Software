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
    /// Interaktionslogik für Gruppenbox.xaml
    /// </summary>
    public partial class Gruppenbox : UserControl
    {
        public Label Gruppenname { get; set; }
        public Label Anzahl { get; set; }
        public ListBox Mannschaften { get; set; }
        public EventHandler Gruppenbox_Leeren { get; set; }
        public EventHandler Gruppenbox_Raus { get; set; }
        public EventHandler Gruppenbox_Hinzufügen { get; set; }
        public EventHandler Gruppenbox_Füllen { get; set; }
        public StackPanel Gruppengroesse_auswahl { get; set; }


        public Gruppenbox()
        {
            InitializeComponent();
            XamlElemente_zuordnen();
        }

        private void XamlElemente_zuordnen()
        {
            Gruppenname = label_gruppenName;
            Anzahl = label_anzahl;
            Mannschaften = listbox_mannschaften;
            Gruppengroesse_auswahl = panel_expand_gruppengroesse;
        }

        private void btn_leeren_Click(object sender, RoutedEventArgs e)
        {
            if (Gruppenbox_Leeren != null)
            {
                Gruppenbox_Leeren(this, null);
            }

        }

        private void btn_raus_Click(object sender, RoutedEventArgs e)
        {
            if (Gruppenbox_Raus != null)
            {
                Gruppenbox_Raus(this, null);
            }

        }

        private void btn_hinzufügen_Click(object sender, RoutedEventArgs e)
        {
            if (Gruppenbox_Hinzufügen != null)
            {
                Gruppenbox_Hinzufügen(this, null);
            }

        }

        private void btn_füllen_Click(object sender, RoutedEventArgs e)
        {
            if (Gruppenbox_Füllen != null)
            {
                Gruppenbox_Füllen(this, null);
            }

        }
    }
}
