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

namespace WpfBattleship
{
    /// <summary>
    /// Interaction logic for Multiplayer.xaml
    /// </summary>
    public partial class Multiplayer : Window
    {
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

                    count++;
                }

            }
           
        }

        string[] ships = new string[] { "EnemyButton1", "EnemyButton12", "EnemyButton23", "EnemyButton34", "EnemyButton45", "EnemyButton56", "EnemyButton67", "EnemyButton78", "EnemyButton89", "EnemyButton100" };


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            if (ships.Contains(b.Name))
            {
                b.Background = b.Background == Brushes.Red ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : Brushes.Red;
            }

            else
            {
                b.Background = b.Background == Brushes.Cyan ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : Brushes.Cyan;
            }
        }
    }
}
