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
    /// Interaction logic for Teilnahmeregel.xaml
    /// </summary>
    public partial class Kandidat_DialogBox : UserControl
    {
        public ComboBox Gruppenauswahl { get; set; }
        public ComboBox Platzierungen { get; set; }
        public EventHandler NeuerKandidat { get; set; }
        public EventHandler KandidatEntfernen { get; set; }
        
        public Kandidat_DialogBox()
        {
            InitializeComponent();
            XamlElemente_zuordnen();
        }

        private void XamlElemente_zuordnen()
        {
            Gruppenauswahl = comboBox_gruppen;
            Platzierungen = comboBox_ranks;
        }

        private void btn_neuerKandidat_Click(object sender, RoutedEventArgs e)
        {
            if (NeuerKandidat != null)
            {
                NeuerKandidat(this, null);
            }
        }

        public void PlusKnopfVerstecken()
        {
            btn_neuerKandidat.Visibility = Visibility.Hidden;
        }

        public void MinusKnopfZeigen()
        {
            btn_Kandidatentfernen.Visibility = Visibility.Visible;
        }

        private void btn_Kandidatentfernen_Click(object sender, RoutedEventArgs e)
        {
            if (KandidatEntfernen != null)
            {
                KandidatEntfernen(this, null);
            }
        }
    }
}
