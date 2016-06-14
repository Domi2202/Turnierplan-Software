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
using System.Windows.Shapes;

namespace Turnierplan_Software
{
    /// <summary>
    /// Interaction logic for Teilnahmeregel_Dialog.xaml
    /// </summary>
    public partial class Teilnahmeregel_Dialog : Window
    {
        public ItemsControl Teilnahmeregeln { get; set; }
        public TextBox NameDerRegel { get; set; }
        public EventHandler RegelSpeichern { get; set; }
        public Teilnahmeregel_Dialog()
        {
            InitializeComponent();
            XamlElemente_zuordnen();
        }

        private void XamlElemente_zuordnen()
        {
            Teilnahmeregeln = panel_regeln;
            NameDerRegel = textBox_name;
        }

        private void btn_cncl_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            if (RegelSpeichern != null)
            {
                RegelSpeichern(this, null);
            }
        }
    }
}
