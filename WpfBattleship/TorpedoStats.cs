using System.Collections.Generic;

namespace NationalInstruments
{
    public class TorpedoStats
    {
        public long? Id { get; set; }
        public Game Game { get; set; }
        public string PlayerName { get; set; }
        public string Winner { get; set; }
        public int NumOfRounds { get; set; }
        public int PlayerHits { get; set; }
        
        public TorpedoStats() {}

        public TorpedoStats(long? id, Game game, string playerName, string winner, int numOfRounds, int playerHits)
        {
            Id = id;
            Game = game;
            PlayerName = playerName;
            Winner = winner;
            NumOfRounds = numOfRounds;
            PlayerHits = playerHits;
        }
    }
}