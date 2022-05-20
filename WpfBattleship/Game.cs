namespace NationalInstruments
{
    public class Game
    {
        public long? Id { get; set; }
        public string GameType { get; set; }
        
        public Game() {}

        public Game(long? id, string gameType)
        {
            Id = id;
            GameType = gameType;
        }
    }
}