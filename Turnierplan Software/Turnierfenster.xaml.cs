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
    /// Interaktionslogik für Turnierfenster.xaml
    /// </summary>
    public partial class Turnierfenster : UserControl
    {
        public Label Turniername { get; set; }
        public EventHandler Mannschaft_Hinzufuegen { get; set; }
        public Turnierfenster()
        {
            InitializeComponent();
            Xaml_Elemente_zuordnen();
        }

        private void Xaml_Elemente_zuordnen()
        {
            Turniername = turnier_name;
        }

        private void mannschaft_hinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            if (Mannschaft_Hinzufuegen != null)
            {
                Mannschaft_Hinzufuegen(this, null);
            }
        }
    }
}
