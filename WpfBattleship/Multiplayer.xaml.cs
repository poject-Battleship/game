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
            
            _player1Name = "Béla";
            _player1Hits = 15;
            _player2Name = "Pista";
            _player2Hits = 14;
            _winner = "Béla";
            _numOfRounds = 30;
        }

        private string[] _ships = new string[]
        {
            "EnemyButton1", "EnemyButton12", "EnemyButton23", "EnemyButton34", "EnemyButton45",
            "EnemyButton56", "EnemyButton67", "EnemyButton78", "EnemyButton89", "EnemyButton100",
            "Button1", "Button12", "Button23", "Button34", "Button45", "Button56", "Button67",
            "Button78", "Button89", "Button100"
        };
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            switch (_currentState)
            {
                case GameState.Player1:
                    if (_p1Territory.Contains(b))
                    {
                        if (_ships.Contains(b.Name))
                        {
                             b.Background = b.Background == Brushes.Red
                                ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"))
                                : Brushes.Red;
                             await Task.Delay(1000);
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
                        if (_ships.Contains(b.Name))
                        {
                            b.Background = b.Background == Brushes.Red
                                ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"))
                                : Brushes.Red;
                            await Task.Delay(1000);
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
            using var ctx = new TorpedoContext();
            ctx.Database.EnsureCreated();

            var game = new Game(null, "multi");
            ctx.Game.Add(game);
            var torpedoStatP1 = new TorpedoStats(null, game, _player1Name, _winner, _numOfRounds, _player1Hits);
            var torpedoStatP2 = new TorpedoStats(null, game, _player2Name, _winner, _numOfRounds, _player2Hits);
            ctx.Torpedo.Add(torpedoStatP1);
            ctx.Torpedo.Add(torpedoStatP2);

            ctx.SaveChanges();
        }
    }
}
