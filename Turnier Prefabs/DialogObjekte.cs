using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Turnier_Prefabs
{
    public class DialogFeld
    {
        public Label Feld_Name { get; set; }
        public UIElement Feld_Inhalt { get; set; }

        public DialogFeld (string Bezeichner_des_Feldes)
        {
            Feld_Name = new Label();
            Feld_Name.Content = Bezeichner_des_Feldes + ":";
            Feld_Name.Height = 25.6;
        }
    }

    public class DialogFeld_Text : DialogFeld
    {
        public DialogFeld_Text (string Bezeichner_des_Feldes) : base (Bezeichner_des_Feldes)
        {
            Feld_Inhalt = new TextBox();
            TextBox Feld_Inhalt_Box = Feld_Inhalt as TextBox;
            Feld_Inhalt_Box.Height = 18;
            Feld_Inhalt_Box.Margin = new Thickness(0, 4.6, 0, 3);
        }
    }

    public class DialogFeld_Checkbox : DialogFeld
    {
        public DialogFeld_Checkbox (string Bezeichner_des_Feldes) : base (Bezeichner_des_Feldes)
        {
            Feld_Inhalt = new CheckBox();
            CheckBox Feld_Inhalt_Box = Feld_Inhalt as CheckBox;
            Feld_Inhalt_Box.Height = 15.2;
            Feld_Inhalt_Box.Margin = new Thickness(0, 7.4, 0, 3);
        }
    }

    public class Dialogfeld_Zahl : DialogFeld
    {
        public Dialogfeld_Zahl (string Bezeichner_des_Feldes) : base (Bezeichner_des_Feldes)
        {
            Feld_Inhalt = new TextBox();
            TextBox Feld_Inhalt_Box = Feld_Inhalt as TextBox;
            Feld_Inhalt_Box.Height = 18;
            Feld_Inhalt_Box.Width = 20;
            Feld_Inhalt_Box.HorizontalAlignment = HorizontalAlignment.Left;
            Feld_Inhalt_Box.TextAlignment = TextAlignment.Center;
            Feld_Inhalt_Box.Margin = new Thickness(0, 4.6, 0, 3);
        }
    }
}
