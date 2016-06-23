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
    /// Interaktionslogik für RundenBox.xaml
    /// </summary>
    public partial class RundenBox : UserControl
    {
        public Grid Spiele { get; set; }
        public EventHandler Nachfolgerrunde { get; set; }
        public EventHandler RundeEntfernen { get; set; }

        public RundenBox()
        {
            InitializeComponent();
            XamlElementeZuordnen();
        }

        private void XamlElementeZuordnen()
        {
            Spiele = grid_spiele;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Nachfolgerrunde != null)
            {
                Nachfolgerrunde(this, null);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RundeEntfernen != null)
            {
                RundeEntfernen(this, null);
            }
        }
    }
}
