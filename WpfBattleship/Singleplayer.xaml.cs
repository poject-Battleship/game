using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading.Tasks;

namespace NationalInstruments
{
    /// <summary>
    /// Interaction logic for Singleplayer.xaml
    /// </summary>
    public partial class SinglePlayer : Window
    {
        private string _playerName;
        private string _winner;
        private int _numOfRounds;
        private int _playerHits;
        public SinglePlayer(string playerName)
        {
            InitializeComponent();
            this.playerName.Text = playerName;
            int count = 1;

            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    Button myControl1 = new Button();
                    myControl1.Content = count.ToString(new CultureInfo("hu-HU"));
                    myControl1.Name = "Button" + count.ToString(new CultureInfo("hu-HU"));
                    myControl1.Click += new RoutedEventHandler(Button_Click);
                    Grid.SetColumn(myControl1, j);
                    Grid.SetRow(myControl1, i);
                    Board.Children.Add(myControl1);

                    count++;
                }
            }

            _playerName = playerName;
            _winner = playerName;
            _numOfRounds = 30;
            _playerHits = 15;
        }

        private int _turns = 0;
        private static readonly string[] _ships = new string[]
        {
            "Button1", "Button12", "Button23",
            "Button34", "Button45", "Button56",
            "Button67", "Button78", "Button89",
            "Button100"
        };

        bool isGameOver = false;
        int shipsSunk = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            if (_ships.Contains(b.Name))
            {
                b.Background = b.Background == Brushes.Red
                    ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"))
                    : Brushes.Red;
                shipsSunk++;
                if (shipsSunk == 10)
                {
                    isGameOver = true;
                }
            }
            else
            {
                b.Background = b.Background == Brushes.Cyan
                    ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"))
                    : Brushes.Cyan;
            }
            _turns++;
            this.turnsTaken.Text = "Turns: " + _turns;
            this.numberOfHits.Text = "My hits: " + shipsSunk;
            this.enemyHits.Text = "Enemy hits: ";
            this.shipsRemaining.Text = "Available ships: " + (10-shipsSunk);
            this.numberOfshipsDestroyed.Text = "Destroyed ships: " + shipsSunk;
            using var ctx = new TorpedoContext();
            //ctx.Database.EnsureCreated();

            var game = new Game(null, "single");
            ctx.Game.Add(game);
            var torpedoStat = new TorpedoStats(null, game, _playerName, _winner, _numOfRounds, _playerHits);
            ctx.Torpedo.Add(torpedoStat);

            //ctx.Torpedo.Where(stat => stat.Game.GameType == "single");

            //ctx.SaveChanges();

            if (isGameOver)
            {
                var victory = new Victory(_winner);
                victory.ShowDialog();
                Close();
            }
        }
    }
}