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
    /// Interaktionslogik für Mannschaftsseite.xaml
    /// </summary>
    public partial class Mannschaftsseite : UserControl
    {
        public Label Mannschaftsname { get; set; }
        public CheckBox Aus_Bayern { get; set; }
        public CheckBox Ist_Spaetstarter { get; set; }
        public ComboBox Altersgruppe { get; set; }
        public ComboBox Geschlecht { get; set; }

        public Mannschaftsseite()
        {
            InitializeComponent();
            Xmal_Elemente_zuordnen();
        }
        private void Xmal_Elemente_zuordnen()
        {
            Mannschaftsname = label_Mannschaftsname;
            Aus_Bayern = checkBox_Bayern;
            Ist_Spaetstarter = checkBox_Spätstarter;
            Altersgruppe = comboBox_Altersklassen;
            Geschlecht = comboBox_Geschlecht;
        }
    }
}
