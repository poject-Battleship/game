using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfBattleship
{
    /// <summary>
    /// Interaction logic for SingleName.xaml
    /// </summary>
    public partial class SingleName : Window
    {
        public SingleName()
        {
            InitializeComponent();
        }

        private void OpenSingleplayer(object sender, RoutedEventArgs e)
        {
            var playername = playerName.Text;
            bool specialdigit = false;
            int i = 0;
                while (i<playername.Length && specialdigit==false)
                {
                    char temp = playername[i];
                    if (!Char.IsLetterOrDigit(temp))
                    {
                    specialdigit = true;
                    }
                i++;
                }
            if (specialdigit==false)
            { 
            var singleplayer = new Singleplayer();
            singleplayer.ShowDialog();
            }
            Close();
        }
    }
}
