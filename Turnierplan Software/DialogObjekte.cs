using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Turnierplan_Software
{
    public abstract class DialogFeld
    {
        public Label Feld_Name { get; set; }
        public UIElement Feld_Inhalt { get; set; }

        public DialogFeld (string Bezeichner_des_Feldes)
        {
            Feld_Name = new Label();
            Feld_Name.Content = Bezeichner_des_Feldes + ":";
            Feld_Name.Height = 25.6;
        }

        public string Get_Name()
        {
            return Convert.ToString(Feld_Name.Content).TrimEnd(':');
        }
        public abstract string Get_Inhalt();

        public abstract void Leerzeichen_korrigieren();
    }

    public class DialogFeld_Text : DialogFeld
    {
        private TextBox _Feld_Inhalt_Box;

        public DialogFeld_Text (string Bezeichner_des_Feldes) : base (Bezeichner_des_Feldes)
        {
            Feld_Inhalt = new TextBox();
            _Feld_Inhalt_Box = Feld_Inhalt as TextBox;
            _Feld_Inhalt_Box.Height = 18;
            _Feld_Inhalt_Box.Margin = new Thickness(0, 4.6, 0, 3);
        }

        public override string Get_Inhalt()
        {
            return Convert.ToString(_Feld_Inhalt_Box.Text);
        }

        public override void Leerzeichen_korrigieren()
        {
            _Feld_Inhalt_Box.Text = _Feld_Inhalt_Box.Text.TrimStart(' ');
            _Feld_Inhalt_Box.Text = _Feld_Inhalt_Box.Text.TrimEnd(' ');
        }
    }

    public class DialogFeld_Checkbox : DialogFeld
    {
        CheckBox _Feld_Inhalt_Box;

        public DialogFeld_Checkbox (string Bezeichner_des_Feldes) : base (Bezeichner_des_Feldes)
        {
            Feld_Inhalt = new CheckBox();
            _Feld_Inhalt_Box = Feld_Inhalt as CheckBox;
            _Feld_Inhalt_Box.Height = 15.2;
            _Feld_Inhalt_Box.Margin = new Thickness(0, 7.4, 0, 3);
        }

        public override string Get_Inhalt()
        {
            return Convert.ToString(_Feld_Inhalt_Box.IsChecked);
        }

        public override void Leerzeichen_korrigieren() { }
    }

    public class DialogFeld_Zahl : DialogFeld
    {
        TextBox _Feld_Inhalt_Box;
        
        public DialogFeld_Zahl (string Bezeichner_des_Feldes) : base (Bezeichner_des_Feldes)
        {
            Feld_Inhalt = new TextBox();
            _Feld_Inhalt_Box = Feld_Inhalt as TextBox;
            _Feld_Inhalt_Box.Height = 18;
            _Feld_Inhalt_Box.Width = 20;
            _Feld_Inhalt_Box.HorizontalAlignment = HorizontalAlignment.Left;
            _Feld_Inhalt_Box.TextAlignment = TextAlignment.Center;
            _Feld_Inhalt_Box.Margin = new Thickness(0, 4.6, 0, 3);
        }

        public override string Get_Inhalt()
        {
            return Convert.ToString(_Feld_Inhalt_Box.Text);
        }

        public override void Leerzeichen_korrigieren()
        {
            _Feld_Inhalt_Box.Text = _Feld_Inhalt_Box.Text.TrimStart(' ');
            _Feld_Inhalt_Box.Text = _Feld_Inhalt_Box.Text.TrimEnd(' ');
        }
    }
}

