using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Turnierplan_Software
{
    public class DropdownElement<T> : ComboBoxItem
    {
        public T Details { get; set; }

        public DropdownElement(T zugehoerige_daten, string name)
        {
            Details = zugehoerige_daten;
            Content = name;
        }
    }
}
