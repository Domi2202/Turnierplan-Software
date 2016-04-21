using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Turnierplan_Software
{
    public class Listenelement<T> : Label where T : new()
    {
        public T Details { get; set; }

        public Listenelement(T zugehoerige_daten, string name)
        {
            Details = zugehoerige_daten;
            Content = name;
        }
    }
}
