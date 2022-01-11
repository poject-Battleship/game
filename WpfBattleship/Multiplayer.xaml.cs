using System;
using System.Linq;
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
using System.Threading.Tasks;

public enum GameState { Player1, Player2 };


namespace WpfBattleship
{
    /// <summary>
    /// Interaction logic for Multiplayer.xaml
    /// </summary>
    public partial class Multiplayer : Window
    {
        List<Button> P1Territory = new List<Button>();
        List<Button> P2Territory = new List<Button>();
        public GameState CurrentState = GameState.Player1;
        public Multiplayer()
        {
            InitializeComponent();

            int count = 1;

            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    Button MyControl1 = new Button();
                    MyControl1.Content = count.ToString();
                    MyControl1.Name = "Button" + count.ToString();
                    MyControl1.Click += new RoutedEventHandler(Button_Click);
                    Grid.SetColumn(MyControl1, j);
                    Grid.SetRow(MyControl1, i);
                    Board.Children.Add(MyControl1);
                    P1Territory.Add(MyControl1);

                    count++;
                }

            }

            count = 1;
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    Button MyControl1 = new Button();
                    MyControl1.Content = count.ToString();
                    MyControl1.Name = "EnemyButton" + count.ToString();
                    MyControl1.Click += new RoutedEventHandler(Button_Click);
                    Grid.SetColumn(MyControl1, j);
                    Grid.SetRow(MyControl1, i);
                    Boardd.Children.Add(MyControl1);
                    P2Territory.Add(MyControl1);

                    count++;
                }

            }
            Boardd.Visibility = Visibility.Hidden;
        }

        string[] ships = new string[] { "EnemyButton1", "EnemyButton12", "EnemyButton23", "EnemyButton34", "EnemyButton45", "EnemyButton56", "EnemyButton67", "EnemyButton78", "EnemyButton89", "EnemyButton100"
        , "Button1", "Button12", "Button23", "Button34", "Button45", "Button56", "Button67", "Button78", "Button89", "Button100"};


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            switch (CurrentState) 
            {
                case GameState.Player1:
                    if (P1Territory.Contains(b))
                    { 

                    if (ships.Contains(b.Name))
                    {
                         b.Background = b.Background == Brushes.Red ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : Brushes.Red;
                         await Task.Delay(1000);
                    }

                    else
                    {
                        b.Background = b.Background == Brushes.Cyan ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : Brushes.Cyan;
                        await Task.Delay(1000);
                    }
                    }
                    Boardd.Visibility = Visibility.Visible;
                    Board.Visibility = Visibility.Hidden;
                    CurrentState = GameState.Player2;
                    break;

                case GameState.Player2:
                    if (P2Territory.Contains(b))
                    {

                        if (ships.Contains(b.Name))
                        {
                            b.Background = b.Background == Brushes.Red ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : Brushes.Red;
                            await Task.Delay(1000);
                        }

                        else
                        {
                            b.Background = b.Background == Brushes.Cyan ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : Brushes.Cyan;
                            await Task.Delay(1000);
                        }
                    }
                    Boardd.Visibility = Visibility.Hidden;
                    Board.Visibility = Visibility.Visible;
                    CurrentState = GameState.Player1;
                    break;

            }
        }
    }
}
