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
        private static readonly string[] planes = new string[]
        {
            "Button2", "Button10", "Button51", "Button47"
        };
        private static readonly string[] destroyer1 = new string[]
        {
            "Button6", "Button7"
        };
        private static readonly string[] destroyer2 = new string[]
        {
            "Button65", "Button66"
        };
        private static readonly string[] destroyer3 = new string[]
        {
            "Button73", "Button83"
        };
        private static readonly string[] cruiser1 = new string[]
        {
            "Button24", "Button34", "Button44"
        };
        private static readonly string[] cruiser2 = new string[]
        {
            "Button28", "Button29", "Button30"
        };
        private static readonly string[] motherShip = new string[]
        {
            "Button59", "Button69", "Button79", "Button89"
        };
 
        private static readonly string[] _ships = new string[]
        {
            "Button2", "Button10", "Button51", "Button47",
            "Button6", "Button7", "Button65", "Button66", "Button73", "Button83",
            "Button24", "Button34", "Button44", "Button28", "Button29", "Button30",
            "Button59", "Button69", "Button79", "Button89"
        };

        List<string> shipList = new List<string>(_ships);
        List<string> cruiser1List = new List<string>(cruiser1);
        List<string> cruiser2List = new List<string>(cruiser2);
        List<string> motherShipList = new List<string>(motherShip);

        bool isGameOver = false;
        int shipsSunk = 10;
        int hits = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            b.IsHitTestVisible = false;

            if (shipList.Contains(b.Name))
            {
                b.Background = b.Background == Brushes.Red
                    ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"))
                    : Brushes.Red;

                if (planes.Contains(b.Name))
                {
                    shipsSunk--;
                }

                if (destroyer1.Contains(b.Name) && (!shipList.Contains(destroyer1[0]) || !shipList.Contains(destroyer1[1])))
                {
                    shipsSunk--;
                }

                if (destroyer2.Contains(b.Name) && (!shipList.Contains(destroyer2[0]) || !shipList.Contains(destroyer2[1])))
                {
                    shipsSunk--;
                }

                if (destroyer3.Contains(b.Name) && (!shipList.Contains(destroyer3[0]) || !shipList.Contains(destroyer3[1])))
                {
                    shipsSunk--;
                }

                if (cruiser1List.Contains(b.Name) && cruiser1List.Count == 1)
                {
                    shipsSunk--;
                }

                if (cruiser2List.Contains(b.Name) && cruiser2List.Count == 1)
                {
                    shipsSunk--;
                }

                if (motherShipList.Contains(b.Name) && motherShipList.Count == 1)
                {
                    shipsSunk--;
                }

                cruiser1List.Remove(b.Name);
                cruiser2List.Remove(b.Name);
                motherShipList.Remove(b.Name);
                shipList.Remove(b.Name);
                hits++;

                if (hits == 20)
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
            this.numberOfHits.Text = "My hits: " + hits;
            this.enemyHits.Text = "Enemy hits: ";
            this.shipsRemaining.Text = "Available ships: " + shipsSunk;
            this.numberOfshipsDestroyed.Text = "Destroyed ships: " + (10 - shipsSunk);
            using var ctx = new TorpedoContext();
            ctx.Database.EnsureCreated();

            var game = new Game(null, "single");
            ctx.Game.Add(game);
            var torpedoStat = new TorpedoStats(null, game, _playerName, _winner, _numOfRounds, _playerHits);
            ctx.Torpedo.Add(torpedoStat);

            //ctx.Torpedo.Where(stat => stat.Game.GameType == "single");

            ctx.SaveChanges();

            if (isGameOver)
            {
                var victory = new Victory(_winner);
                victory.ShowDialog();
                Close();
            }
        }
    }
}