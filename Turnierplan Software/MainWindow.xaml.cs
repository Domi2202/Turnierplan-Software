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
using Turnier_Controller;

namespace Turnierplan_Software
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_turnier_hinzufuegen_handler(object sender, RoutedEventArgs e)
        {
            Label turniername = new Label();
            turniername.Content = "Turnier";
            this.listbox_turniere.Items.Add(turniername);
        }

        private void button_veranstaltung_erstellen_Click(object sender, RoutedEventArgs e)
        {
            Window Dialog = new Dialog_Objektdetails(new VeranstaltungsErsteller());
            Dialog.Show();
            //nue veranstaltung und name steht danach im label
        }
    }
}
