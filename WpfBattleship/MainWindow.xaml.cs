using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NationalInstruments
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenSingleName(object sender, RoutedEventArgs e)
        {
            var singleName = new SingleName();
            singleName.ShowDialog();
        }

        private void OpenMultiName(object sender, RoutedEventArgs e)
        {
            var multiName = new MultiName();
            multiName.ShowDialog();
        }

        private void OpenPlayerStats(object sender, RoutedEventArgs e)
        {
            var playerStats = new PlayerStats();
            playerStats.ShowDialog();
        }
    }
}
