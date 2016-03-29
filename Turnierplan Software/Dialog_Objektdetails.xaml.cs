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
using Turnier_Controller;
using Turnier_Prefabs;

namespace Turnierplan_Software
{
    /// <summary>
    /// Interaktionslogik für Dialog_Objektdetails.xaml
    /// </summary>
    public partial class Dialog_Objektdetails : Window
    {
        public Dialog_Objektdetails(string name)
        {
            InitializeComponent();
            this.Title = name;
            foreach (DialogFeld dialog_feld in VeranstaltungsErsteller.Dialog_bereitstellen())
            {
                panel_name.Children.Add(dialog_feld.Feld_Name);
                panel_value.Children.Add(dialog_feld.Feld_Inhalt);
            }
        }
    }
}
