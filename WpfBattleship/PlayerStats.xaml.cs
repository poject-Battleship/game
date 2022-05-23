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
    /// Interaction logic for PlayerStats.xaml
    /// </summary>
    public partial class PlayerStats : Window
    {
        public PlayerStats()
        {
            InitializeComponent();
            SinglePlayerDatabase johnSmith = new SinglePlayerDatabase();
            johnSmith.PlayerName = "John Smith";
            johnSmith.Winner = "AI";
            johnSmith.NumberOfRounds = 22;
            johnSmith.PlayerHits = 10;

            SinglePlayerDataGridXAML.Items.Add(johnSmith);
        }

        public class SinglePlayerDatabase
        {
            public string PlayerName { get; set; }
            public string Winner { get; set; }
            public int NumberOfRounds { get; set; }
            public int PlayerHits { get; set; }

        }
    }
}
