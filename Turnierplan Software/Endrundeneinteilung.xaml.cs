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
    public partial class Endrundeneinteilung : UserControl
    {
        public Label label_Turniername { get; set; }
        public ComboBox Modus_Auswahl { get; set; }
        public CheckBox checkbox_Punkte { get; set; }
        public ListBox listbox_Teilnehmer { get; set; }
        public ItemsControl Endrundenbaum { get; set; }
        public EventHandler AddParticipationRule { get; set; }
        public EventHandler DeleteParticipationRule { get; set; }
        public EventHandler TeilnahmeregelAnzeigen { get; set; }
        public EventHandler EndrundenbaumErzeugen { get; set; }
        public EventHandler VerliererbaumZeigen { get; set; }
        public EventHandler GewinnerbaumZeigen { get; set; }

        public Endrundeneinteilung()
        {

            InitializeComponent();
            XamlElemente_zuordnen();


        }
        private void XamlElemente_zuordnen()
        {
            label_Turniername = label_turniername;
            checkbox_Punkte = checkBox_3punkte;
            listbox_Teilnehmer = listBox_teilnehmer;
            Endrundenbaum = grid_endrundenbaum;
            Modus_Auswahl = combobox_modus;
        }

        private void btn_rule_add_Click(object sender, RoutedEventArgs e)
        {
            if (AddParticipationRule != null)
            {
                AddParticipationRule(this, null);
            }
        }

        private void btn_rule_delete_Click(object sender, RoutedEventArgs e)
        {
            if (DeleteParticipationRule != null)
            {
                DeleteParticipationRule(this, null);
            }
        }

        private void btn_rule_info_Click(object sender, RoutedEventArgs e)
        {
            if (TeilnahmeregelAnzeigen != null)
            {
                TeilnahmeregelAnzeigen(this, null);
            }
        }

        private void button_ok_Click(object sender, RoutedEventArgs e)
        {
            if (EndrundenbaumErzeugen != null)
            {
                EndrundenbaumErzeugen(this, null);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (GewinnerbaumZeigen != null)
            {
                GewinnerbaumZeigen(this, null);
            }
        }

        private void btn_verliererbaum_Click(object sender, RoutedEventArgs e)
        {
            if (VerliererbaumZeigen != null)
            {
                VerliererbaumZeigen(this, null);
            }
        }
    }
}
