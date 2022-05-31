using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace NationalInstruments
{
    public enum GameState { Player1, Player2 }

    /// <summary>
    /// Interaction logic for Multiplayer.xaml
    /// </summary>
    public partial class Multiplayer : Window
    {
        private List<Button> _p1Territory = new List<Button>();
        private List<Button> _p2Territory = new List<Button>();
        private GameState _currentState = GameState.Player1;

        private string _player1Name;
        private string _player2Name;
        private string _winner;
        private int _numOfRounds;
        private int _player1Hits;
        private int _player2Hits;
        public Multiplayer(string player1Name, string player2Name)
        {
            InitializeComponent();

            PlayerOneName.Text = player1Name;
            PlayerTwoName.Text = player2Name;

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
                    _p1Territory.Add(myControl1);

                    count++;
                }
            }

            count = 1;
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    Button myControl1 = new Button();
                    myControl1.Content = count.ToString(new CultureInfo("hu-HU"));
                    myControl1.Name = "EnemyButton" + count.ToString(new CultureInfo("hu-HU"));
                    myControl1.Click += new RoutedEventHandler(Button_Click);
                    Grid.SetColumn(myControl1, j);
                    Grid.SetRow(myControl1, i);
                    Boardd.Children.Add(myControl1);
                    _p2Territory.Add(myControl1);

                    count++;
                }
            }
            Boardd.Visibility = Visibility.Hidden;
            _player1Name = player1Name;
            _player1Hits = p1hits;
            _player2Name = player2Name;
            _player2Hits = p2hits;
            _winner = _winner;
            _numOfRounds = _turns;
        }

        private static readonly string[] p1planes = new string[]
        {
            "Button2", "Button10", "Button51", "Button47"
        };
        private static readonly string[] p1destroyer1 = new string[]
        {
            "Button6", "Button7"
        };
        private static readonly string[] p1destroyer2 = new string[]
        {
            "Button65", "Button66"
        };
        private static readonly string[] p1destroyer3 = new string[]
        {
            "Button73", "Button83"
        };
        private static readonly string[] p1cruiser1 = new string[]
        {
            "Button24", "Button34", "Button44"
        };
        private static readonly string[] p1cruiser2 = new string[]
        {
            "Button28", "Button29", "Button30"
        };
        private static readonly string[] p1motherShip = new string[]
        {
            "Button59", "Button69", "Button79", "Button89"
        };
        private static readonly string[] p2planes = new string[]
       {
            "EnemyButton2", "EnemyButton10", "EnemyButton51", "EnemyButton47"
       };
        private static readonly string[] p2destroyer1 = new string[]
        {
            "EnemyButton6", "EnemyButton7"
        };
        private static readonly string[] p2destroyer2 = new string[]
        {
            "EnemyButton65", "EnemyButton66"
        };
        private static readonly string[] p2destroyer3 = new string[]
        {
            "EnemyButton73", "EnemyButton83"
        };
        private static readonly string[] p2cruiser1 = new string[]
        {
            "EnemyButton24", "EnemyButton34", "EnemyButton44"
        };
        private static readonly string[] p2cruiser2 = new string[]
        {
            "EnemyButton28", "EnemyButton29", "EnemyButton30"
        };
        private static readonly string[] p2motherShip = new string[]
        {
            "EnemyButton59", "EnemyButton69", "EnemyButton79", "EnemyButton89"
        };
        private static readonly string[] p1ships = new string[]
        {
            "Button2", "Button10", "Button51", "Button47",
            "Button6", "Button7", "Button65", "Button66", "Button73", "Button83",
            "Button24", "Button34", "Button44", "Button28", "Button29", "Button30",
            "Button59", "Button69", "Button79", "Button89"
        };
        private static readonly string[] p2ships = new string[]
        {
            "EnemyButton2", "EnemyButton10", "EnemyButton51", "EnemyButton47",
            "EnemyButton6", "EnemyButton7", "EnemyButton65", "EnemyButton66", "EnemyButton73", "EnemyButton83",
            "EnemyButton24", "EnemyButton34", "EnemyButton44", "EnemyButton28", "EnemyButton29", "EnemyButton30",
            "EnemyButton59", "EnemyButton69", "EnemyButton79", "EnemyButton89"
        };



        List<string> p1shipList = new List<string>(p1ships);
        List<string> p1cruiser1List = new List<string>(p1cruiser1);
        List<string> p1cruiser2List = new List<string>(p1cruiser2);
        List<string> p1motherShipList = new List<string>(p1motherShip);
        List<string> p2shipList = new List<string>(p2ships);
        List<string> p2cruiser1List = new List<string>(p2cruiser1);
        List<string> p2cruiser2List = new List<string>(p2cruiser2);
        List<string> p2motherShipList = new List<string>(p2motherShip);

        private int _turns = 0;
        bool isGameOver = false;
        private int p1shipsSunk = 0;
        private int p2shipsSunk = 0;
        int p1hits = 0;
        int p2hits = 0;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            b.IsHitTestVisible = false;

            switch (_currentState)
            {
                case GameState.Player1:
                    if (_p1Territory.Contains(b))
                    {
                        _turns++;
                        if (p1ships.Contains(b.Name))
                        {
                             b.Background = b.Background == Brushes.Red
                                ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"))
                                : Brushes.Red;
                            if (p1planes.Contains(b.Name))
                            {
                                p1shipsSunk++;
                            }

                            if (p1destroyer1.Contains(b.Name) && (!p1shipList.Contains(p1destroyer1[0]) || !p1shipList.Contains(p1destroyer1[1])))
                            {
                                p1shipsSunk++;
                            }

                            if (p1destroyer2.Contains(b.Name) && (!p1shipList.Contains(p1destroyer2[0]) || !p1shipList.Contains(p1destroyer2[1])))
                            {
                                p1shipsSunk++;
                            }

                            if (p1destroyer3.Contains(b.Name) && (!p1shipList.Contains(p1destroyer3[0]) || !p1shipList.Contains(p1destroyer3[1])))
                            {
                                p1shipsSunk++;
                            }

                            if (p1cruiser1List.Contains(b.Name) && p1cruiser1List.Count == 1)
                            {
                                p1shipsSunk++;
                            }

                            if (p1cruiser2List.Contains(b.Name) && p1cruiser2List.Count == 1)
                            {
                                p1shipsSunk++;
                            }

                            if (p1motherShipList.Contains(b.Name) && p1motherShipList.Count == 1)
                            {
                                p1shipsSunk++;
                            }

                            p1cruiser1List.Remove(b.Name);
                            p1cruiser2List.Remove(b.Name);
                            p1motherShipList.Remove(b.Name);
                            p1shipList.Remove(b.Name);
                            p1hits++;

                            await Task.Delay(1000);
                            if (p1hits == p1ships.Length)
                            {
                                _winner = _player1Name;
                                isGameOver = true;
                            }
                        }
                        else
                        {
                            b.Background = b.Background == Brushes.Cyan
                                ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"))
                                : Brushes.Cyan;
                            await Task.Delay(1000);
                        }
                    }
                    Boardd.Visibility = Visibility.Visible;
                    Board.Visibility = Visibility.Hidden;
                    _currentState = GameState.Player2;
                    break;

                case GameState.Player2:
                    if (_p2Territory.Contains(b))
                    {
                        if (p2ships.Contains(b.Name))
                        {
                            b.Background = b.Background == Brushes.Red
                                ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"))
                                : Brushes.Red;

                            if (p2planes.Contains(b.Name))
                            {
                                p2shipsSunk++;
                            }

                            if (p2destroyer1.Contains(b.Name) && (!p2shipList.Contains(p2destroyer1[0]) || !p2shipList.Contains(p2destroyer1[1])))
                            {
                                p2shipsSunk++;
                            }

                            if (p2destroyer2.Contains(b.Name) && (!p2shipList.Contains(p2destroyer2[0]) || !p2shipList.Contains(p2destroyer2[1])))
                            {
                                p2shipsSunk++;
                            }

                            if (p2destroyer3.Contains(b.Name) && (!p2shipList.Contains(p2destroyer3[0]) || !p2shipList.Contains(p2destroyer3[1])))
                            {
                                p2shipsSunk++;
                            }

                            if (p2cruiser1List.Contains(b.Name) && p2cruiser1List.Count == 1)
                            {
                                p2shipsSunk++;
                            }

                            if (p2cruiser2List.Contains(b.Name) && p2cruiser2List.Count == 1)
                            {
                                p2shipsSunk++;
                            }

                            if (p2motherShipList.Contains(b.Name) && p2motherShipList.Count == 1)
                            {
                                p2shipsSunk++;
                            }

                            p2cruiser1List.Remove(b.Name);
                            p2cruiser2List.Remove(b.Name);
                            p2motherShipList.Remove(b.Name);
                            p2shipList.Remove(b.Name);

                            await Task.Delay(1000);
                            p2hits++;
                            if (p2hits == p2ships.Length)
                            {
                                _winner = _player2Name;
                                isGameOver = true;
                            }
                        }
                        else
                        {
                            b.Background = b.Background == Brushes.Cyan
                                ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"))
                                : Brushes.Cyan;
                            await Task.Delay(1000);
                        }
                    }
                    Boardd.Visibility = Visibility.Hidden;
                    Board.Visibility = Visibility.Visible;
                    _currentState = GameState.Player1;
                    break;
            }

            this.p1turnsTaken.Text = "Turns: " + _turns;
            this.p1numberOfHits.Text = "My hits: " + p1hits;
            this.p1enemyHits.Text = "Enemy hits: " + p2hits;
            this.p1shipsRemaining.Text = "Available ships: " + (10 - p1shipsSunk);
            this.p1numberOfshipsDestroyed.Text = "Destroyed ships: " + p1shipsSunk;

            this.p2turnsTaken.Text = "Turns: " + _turns;
            this.p2numberOfHits.Text = "My hits: " + p2hits;
            this.p2enemyHits.Text = "Enemy hits: " + p1hits;
            this.p2shipsRemaining.Text = "Available ships: " + (10 - p2shipsSunk);
            this.p2numberOfshipsDestroyed.Text = "Destroyed ships: " + p2shipsSunk;

            /*using var ctx = new TorpedoContext();
            //ctx.Database.EnsureCreated();

            var game = new Game(null, "multi");
            ctx.Game.Add(game);
            var torpedoStatP1 = new TorpedoStats(null, game, _player1Name, _winner, _numOfRounds, _player1Hits);
            var torpedoStatP2 = new TorpedoStats(null, game, _player2Name, _winner, _numOfRounds, _player2Hits);
            ctx.Torpedo.Add(torpedoStatP1);
            ctx.Torpedo.Add(torpedoStatP2);*/

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
