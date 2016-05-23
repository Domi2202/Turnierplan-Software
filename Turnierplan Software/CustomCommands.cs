using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Turnierplan_Software
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Modus_setzen = new RoutedUICommand("Modus setzen", "Modus setzen", typeof(CustomCommands));
    }
}
