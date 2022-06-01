using System;
using System.Collections.Generic;
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
    /// Interaction logic for PlayerStats.xaml
    /// </summary>
    public partial class PlayerStats : Window
    {
        public PlayerStats()
        {
            InitializeComponent();
            using var ctx = new TorpedoContext();
            ctx.Database.EnsureCreated();

            IList<Game> games = ctx.Game.OrderBy(game => game.Id).ToList();

            foreach (var game in games)
            {
                IList<TorpedoStats> torpedoStats = ctx.Torpedo.Where(torpedoStat =>
                    torpedoStat.Game == game).ToList();
                foreach (var torpedoStat in torpedoStats)
                {
                    if (game.GameType.Equals("single"))
                    {
                        SinglePlayerDataGridXAML.Items.Add(torpedoStat);
                    }
                    else
                    {
                        MultiplayerDataGridXAML.Items.Add(torpedoStat);
                    }
                }
            }

            //SinglePlayerDataGridXAML.Items.Add(johnSmith);
        }

        public class SinglePlayerDatabase
        {
            public string PlayerName { get; set; }
            public string Winner { get; set; }
            public int NumberOfRounds { get; set; }
            public int PlayerHits { get; set; }

        }
    }
}
