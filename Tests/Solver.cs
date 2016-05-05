using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms;

namespace Tests
{
    public class Solver
    {
        public Inning SolveInning(IEnumerable<Player> availablePlayersList)
        {
            var players = availablePlayersList as IList<Player> ?? availablePlayersList.ToList();
            if (!IsSolvable(players))
                return new Inning() { Solvable = false};

            var fielded = Enumerable.Range(0, 10)
                .Select(i => new PlayerAssignment
                {
                    Player = players.ElementAt(i),
                    Position = (Position?) i
                }).ToList();

            var benched = Enumerable.Range(0, players.Count - 10)
                .Select(i => new PlayerAssignment
                {
                    Player = players.ElementAt(i+10),
                }).ToList();

            var all = fielded.Concat(benched).ToList();
            
            return new Inning()
            {
                Solvable = true,
                PlayerAssignments = all
            };
        }

        private bool IsSolvable(IEnumerable<Player> players)
        {
            if (players == null)
                return false;

            if (!players.Any())
                return false;
            if (players.Count() < 10)
                return false;
            if (players.Count(a => a.Gender == Gender.Female) < 3)
                return false;
            if (players.Count(a => a.Gender == Gender.Male) < 3)
                return false;

            return true;
        }
    }
}