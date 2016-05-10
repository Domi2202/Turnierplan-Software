﻿using System;
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
    /// Interaktionslogik für Gruppeneinteilung.xaml
    /// </summary>
    public partial class Gruppeneinteilung : UserControl
    {

        public Label Label_Turniername { get; set; }
        public ComboBox Anzahl_Gruppen { get; set; }
        public Label Label_Zahl { get; set; }
        public Label Label_Poolzahl { get; set; }
        public ListBox Listbox_Pool { get; set; }
        public EventHandler Btn_Zuteilen { get; set; }
        public EventHandler Btn_Ausleeren { get; set; }
        public EventHandler Btn_Bestätigen { get; set; }
        public EventHandler Btn_Rechts { get; set; }
        public EventHandler Btn_Links { get; set; }



        public Gruppeneinteilung()
        {
            InitializeComponent();
        }

        private void btn_zuteilen_Click(object sender, RoutedEventArgs e)
        {
            if (Btn_Zuteilen != null)
            {
                Btn_Zuteilen(this, null);
            }
        }

        private void btn_ausleeren_Click(object sender, RoutedEventArgs e)
        {
            if (Btn_Ausleeren != null)
            {
                Btn_Ausleeren(this, null);
            }
        }

        private void btn_bestätigen_Click(object sender, RoutedEventArgs e)
        {
            if (Btn_Bestätigen != null)
            {
                Btn_Bestätigen(this, null);
            }
        }

        private void btn_rechts_Click(object sender, RoutedEventArgs e)
        {
            if (Btn_Rechts != null)
            {
                Btn_Rechts(this, null);
            }
        }

        private void btn_links_Click(object sender, RoutedEventArgs e)
        {
            if (Btn_Links != null)
            {
                Btn_Links(this, null);
            }
        }
    }
}
