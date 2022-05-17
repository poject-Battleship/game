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
        private void OpenSinglePlayer(object sender, RoutedEventArgs e)
        {
            string playerNameTextBox = this.playerNameTextBox.Text;
            bool specialDigit = false;
            int i = 0;
            while (i < playerNameTextBox.Length && specialDigit == false)
            {
                char temp = playerNameTextBox[i];
                if (!char.IsLetterOrDigit(temp))
                {
                    specialDigit = true;
                }
                i++;
            }
            if (specialDigit == false)
            {
                var singlePlayer = new SinglePlayer();
                singlePlayer.ShowDialog();
                singlePlayer.PlayerName = playerNameTextBox;
            }
            Close();
        }
    }
}