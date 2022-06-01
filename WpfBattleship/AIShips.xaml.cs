using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for AIShips.xaml
    /// </summary>
    public partial class AIShips : Window
    {
        public AIShips()
        {
            InitializeComponent();

            int count = 1;

            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    Button myControl1 = new Button();
                    myControl1.Content = count.ToString(new CultureInfo("hu-HU"));
                    myControl1.Name = "EnemyButton" + count.ToString(new CultureInfo("hu-HU"));
                    myControl1.IsHitTestVisible = false;
                    Grid.SetColumn(myControl1, j);
                    Grid.SetRow(myControl1, i);

                    if (enemyShipList.Contains(myControl1.Name))
                    {
                        myControl1.Background = myControl1.Background == Brushes.Red
                    ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"))
                    : Brushes.Red;
                    }

                    Boardd.Children.Add(myControl1);

                    count++;
                }
            }
        }

        private static readonly string[] enemyShips = new string[]
        {
            "EnemyButton2", "EnemyButton10", "EnemyButton51", "EnemyButton47",
            "EnemyButton6", "EnemyButton7", "EnemyButton65", "EnemyButton66", "EnemyButton73", "EnemyButton83",
            "EnemyButton24", "EnemyButton34", "EnemyButton44", "EnemyButton28", "EnemyButton29", "EnemyButton30",
            "EnemyButton59", "EnemyButton69", "EnemyButton79", "EnemyButton89"
        };
        List<string> enemyShipList = new List<string>(enemyShips);
    }
}