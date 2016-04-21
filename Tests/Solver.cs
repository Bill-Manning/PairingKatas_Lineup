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
            if (!availablePlayersList.Any())
                return new Inning {Solvable = false};

            var fielded = Enumerable.Range(0, 10)
                .Select(i => new PlayerAssignment
                {
                    Player = availablePlayersList.ElementAt(i),
                    Position = (Position?) i
                }).ToList();

            var benched = Enumerable.Range(0, 6)
                .Select(i => new PlayerAssignment
                {
                    Player = availablePlayersList.ElementAt(i+10),
                }).ToList();

            var all = fielded.Concat(benched).ToList();
            
            return new Inning()
            {
                PlayerAssignments = all
            };
        }
    }
}