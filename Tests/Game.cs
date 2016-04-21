using System.Collections.Generic;
using Algorithms;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class Game
    {
        public string Opponent;
        public int Number;
        public Inning[] SolvedInnings { get; set; }
        public List<Player> AvailablePlayers { get; }

        public Game()
        {
            Opponent = string.Empty;
            Number = 1;
            SolvedInnings = new Inning[7];
            AvailablePlayers = new List<Player>();
        }
    }
}