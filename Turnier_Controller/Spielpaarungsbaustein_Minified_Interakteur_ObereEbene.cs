using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Turnierplan_Software;
using Turnierklassen;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Turnier_Controller
{
    class Spielpaarungsbaustein_Minified_Interakteur_ObereEbene : Spielpaarungsbaustein_Minified_Interakteur
    {
        public EventHandler RegelAusPoolGenommen { get; set; }
        public EventHandler RegelInPoolGelegt { get; set; }

        public Spielpaarungsbaustein_Minified_Interakteur_ObereEbene(Paarung paarung, ListBox pool) : base(paarung)
        {
            _Pool = pool;
            SetEventListeners();
        }
    }
}
