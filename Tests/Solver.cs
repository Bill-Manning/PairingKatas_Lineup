using System.Collections.Generic;
using System.Linq;
using Algorithms;

namespace Tests
{
    public class Solver
    {
        public Inning SolveInning()
        {
            var fielded = Enumerable.Range(0, 10)
                .Select(i => new PlayerAssignment
                {
                    Position = (Position?) i
                }).ToList();

            var benched = Enumerable.Range(11, 6)
                .Select(i => new PlayerAssignment
                {}).ToList();

            var all = fielded.Concat(benched).ToList();
            
            return new Inning()
            {
                PlayerAssignments = all
            };
        }
    }
}