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

namespace NationalInstruments
{
    /// <summary>
    /// Interaction logic for Singleplayer.xaml
    /// </summary>
    public partial class SinglePlayer : Window
    {
        public SinglePlayer()
        {
            InitializeComponent();
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
        }

        private int _turns = 0;
        private static readonly string[] _ships = new string[]
        {
            "Button1", "Button12", "Button23",
            "Button34", "Button45", "Button56",
            "Button67", "Button78", "Button89",
            "Button100"
        };

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            if (_ships.Contains(b.Name))
            {
                b.Background = b.Background == Brushes.Red
                    ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"))
                    : Brushes.Red;
            }
            else
            {
                b.Background = b.Background == Brushes.Cyan
                    ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"))
                    : Brushes.Cyan;
            }

            _turns++;
        }
    }
}