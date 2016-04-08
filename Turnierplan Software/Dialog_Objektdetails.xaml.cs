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
    /// Interaktionslogik für Dialog_Objektdetails.xaml
    /// </summary>
    public partial class Dialog_Objektdetails : Window
    {
        public EventHandler Input_Submitted;
        public EventHandler Input_Canceled;
        public UIElementCollection Panel_Keys;
        public UIElementCollection Panel_Values;

        public Dialog_Objektdetails()
        {
            InitializeComponent();
            Panel_Keys = panel_name.Children;
            Panel_Values = panel_value.Children;         
        }

        public void ResizeWindowHeight(double amount)
        {
            Height += amount;
            hauptraster.Height += amount;
            panel_name.Height += amount;
            panel_value.Height += amount;
        }

        private void button_abbrechen_Click(object sender, RoutedEventArgs e)
        {
            if (Input_Canceled != null)
            {
                Input_Canceled(this, null);
            }
        }

        private void button_bestaetigen_Click(object sender, RoutedEventArgs e)
        {
            if (Input_Submitted != null)
            {
                Input_Submitted(this, null);
            }
        }
    }
}
