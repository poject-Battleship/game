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

namespace NationalInstruments
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
            string playerName = this.playerName.Text;
            bool specialdigit = false;
            int i = 0;
            while (i < playerName.Length && specialdigit==false)
            {
                char temp = playerName[i];
                if (!Char.IsLetterOrDigit(temp))
                {
                    specialdigit = true;
                }
                i++;
            }
            if (specialdigit==false)
            {
                var singleplayer = new SinglePlayer();
                singleplayer.ShowDialog();
            }
            Close();
        }
    }
}