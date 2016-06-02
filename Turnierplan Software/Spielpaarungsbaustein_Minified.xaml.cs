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
    /// Interaction logic for Spielpaarungsbaustein_Minified.xaml
    /// </summary>
    public partial class Spielpaarungsbaustein_Minified : UserControl
    {
        public EventHandler TeamA_Add { get; set; }
        public EventHandler TeamB_Add { get; set; }
        public EventHandler TeamA_Remove { get; set; }
        public EventHandler TeamB_Remove { get; set; }

        public Spielpaarungsbaustein_Minified()
        {
            InitializeComponent();
        }

        private void button_teamA_add_Click(object sender, RoutedEventArgs e)
        {
            if (TeamA_Add != null)
            {
                TeamA_Add(this, null);
            }
        }

        private void button_teamA_remove_Click(object sender, RoutedEventArgs e)
        {
            if (TeamA_Remove != null)
            {
                TeamA_Remove(this, null);
            }
        }

        private void button_teamB_add_Click(object sender, RoutedEventArgs e)
        {
            if (TeamB_Add != null)
            {
                TeamB_Add(this, null);
            }
        }

        private void button_teamB_remove_Click(object sender, RoutedEventArgs e)
        {
            if (TeamB_Remove != null)
            {
                TeamB_Remove(this, null);
            }
        }
    }
}
