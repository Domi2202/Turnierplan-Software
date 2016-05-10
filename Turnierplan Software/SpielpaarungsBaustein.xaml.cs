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
    /// Interaktionslogik für SpielpaarungsBaustein.xaml
    /// </summary>
    public partial class SpielpaarungsBaustein : UserControl
    {
        public Label SpielfeldNummer { get; set; }
        public Label UhrzeitEintrag { get; set; }
        public Label Mannschaftsname1 { get; set; }
        public Label ErgebnisHZ1 { get; set; }
        public Label ErgebnisHZ2 { get; set; }
        public Label ErgebnisPenalty { get; set; }
        public Label Mannschaftsname2 { get; set; }


        public SpielpaarungsBaustein()
        {
            InitializeComponent();
        }
    }
}
