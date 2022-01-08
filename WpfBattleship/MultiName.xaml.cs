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
    /// Interaction logic for MultiName.xaml
    /// </summary>
    public partial class MultiName : Window
    {
        public MultiName()
        {
            InitializeComponent();
        }

        private void OpenMultiplayer(object sender, RoutedEventArgs e)
        {
            var player1name = player1Name.Text;
            var player2name = player2Name.Text;
            string names = player1name + player2name;
            bool specialdigit = false;
            int i = 0;
            while (i < names.Length && specialdigit == false)
            {
                char temp = names[i];
                if (!Char.IsLetterOrDigit(temp))
                {
                    specialdigit = true;
                }
                i++;
            }
            if (specialdigit == false)
            { 

                var multiplayer = new Multiplayer();
                multiplayer.ShowDialog();
            }

            Close();
        }
    }
}
