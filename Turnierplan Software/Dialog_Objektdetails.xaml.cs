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
        private ObjektErsteller _Ersteller;
        public Dialog_Objektdetails(ObjektErsteller ersteller)
        {
            InitializeComponent();
            _Ersteller = ersteller;
            Titel_setzen();
            Dialog_aufbauen();            
        }

        private void Titel_setzen()
        {
            Title = _Ersteller.Dialogtyp;
        }

        private void Dialog_aufbauen()
        {
            foreach (DialogFeld dialog_feld in _Ersteller.Dialogfelder_bereitstellen())
            {
                Fenster_anpassen(dialog_feld);
                Dialogfeld_setzen(dialog_feld);
            }
        }

        private void Fenster_anpassen(DialogFeld dialog_feld)
        {
            double betrag = dialog_feld.Feld_Name.Height;
            Height += betrag;
            hauptraster.Height += betrag;
            panel_name.Height += betrag;
            panel_value.Height += betrag;
        }

        private void Dialogfeld_setzen(DialogFeld dialog_feld)
        {
            panel_name.Children.Add(dialog_feld.Feld_Name);
            panel_value.Children.Add(dialog_feld.Feld_Inhalt);
        }

        private void button_abbrechen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_bestaetigen_Click(object sender, RoutedEventArgs e)
        {
            _Ersteller.Anfrage_entgegennehmen();
            this.Close();
        }
    }
}
