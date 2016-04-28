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
            if (availablePlayersList == null)
                return new Inning {Solvable = false};

            var playersList = availablePlayersList as IList<Player> ?? availablePlayersList.ToList();

            if (!playersList.Any())
                return new Inning {Solvable = false};
            if (playersList.Count < 10)
                return new Inning { Solvable = false };
            if (playersList.Count(a => a.Gender == Gender.Female) < 3)
                return new Inning {Solvable = false};
            if (playersList.Count(a => a.Gender == Gender.Male) < 3)
                return new Inning { Solvable = false };


            var fielded = Enumerable.Range(0, 10)
                .Select(i => new PlayerAssignment
                {
                    Player = playersList.ElementAt(i),
                    Position = (Position?) i
                }).ToList();

            var benched = Enumerable.Range(0, playersList.Count - 10)
                .Select(i => new PlayerAssignment
                {
                    Player = playersList.ElementAt(i+10),
                }).ToList();

            var all = fielded.Concat(benched).ToList();
            
            return new Inning()
            {
                Solvable = true,
                PlayerAssignments = all
            };
        }
    }
}