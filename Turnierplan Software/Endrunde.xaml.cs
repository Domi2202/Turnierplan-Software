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
    /// Interaktionslogik für Endrunde.xaml
    /// </summary>
    public partial class Endrunde : UserControl
    {
        public Label label_Turniername { get; set; }
        public Label label_Teilnehmerzahl { get; set; }
        public RadioButton radiobutton_Sechzehntel { get; set; }
        public RadioButton radiobutton_Achtel { get; set; }
        public RadioButton radiobutton_Viertel { get; set; }
        public RadioButton radiobutton_Halb { get; set; }
        public RadioButton radiobutton_Finale{ get; set; }
        public CheckBox checkbox_Punkte { get; set; }
        public ListBox listbox_Teilnehmer { get; set; }
        public Grid grid_Teilnehmer { get; set; }


        public Endrunde()
        {

            InitializeComponent();
            XamlElemente_zuordnen();


        }
        private void XamlElemente_zuordnen()
        {
            label_Turniername = label_turniername;
            label_Teilnehmerzahl = label_teilnehmerzahl;
            radiobutton_Sechzehntel = radioButton_sechzehntel;
            radiobutton_Achtel = radioButton_achtel;
            radiobutton_Viertel = radioButton_viertel;
            radiobutton_Halb = radioButton_halb;
            radiobutton_Finale = radioButton_finale;
            checkbox_Punkte = checkBox_3punkte;
            listbox_Teilnehmer = listBox_teilnehmer;
            grid_Teilnehmer = grid_teilnehmer;

        }
    }
}
