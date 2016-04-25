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
    /// Interaction logic for AnfrageFenster.xaml
    /// </summary>
    public partial class AnfrageFenster : Window
    {
        public EventHandler Bestaetigung_gegeben { get; set; }
        public EventHandler Bestaetigung_nicht_gegeben { get; set; }
        public EventHandler Schliessen { get; set; }
        public AnfrageFenster(string anfrage_an_nutzer)
        {
            InitializeComponent();
            textBlock_anfrage.Text = anfrage_an_nutzer;
        }

        private void button_ja_Click(object sender, RoutedEventArgs e)
        {
            if(Bestaetigung_gegeben != null)
            {
                Bestaetigung_gegeben(this, null);
            }
        }

        private void button_nein_Click(object sender, RoutedEventArgs e)
        {
            if (Bestaetigung_nicht_gegeben != null)
            {
                Bestaetigung_nicht_gegeben(this, null);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (Schliessen != null)
            {
                Schliessen(this, null);
            }
        }
    }
}
