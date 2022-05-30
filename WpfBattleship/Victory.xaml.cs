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
    /// Interaction logic for Victory.xaml
    /// </summary>
    public partial class Victory : Window
    {
        public Victory(string _winner)
        {
            InitializeComponent();

            this.vicotryText.Text = _winner + " has triumphed!";
        }
    }
}
