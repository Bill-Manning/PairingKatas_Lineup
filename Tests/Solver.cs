using System.Collections.Generic;
using System.Linq;
using Algorithms;

namespace Tests
{
    public class Solver
    {
        public Inning SolveInning()
        {
            return new Inning()
            {
                FieldPositions = Enumerable.Range(1, 16).Select(a => new FieldPosition { Position = (Position?)a}).ToList()
            };
        }
    }
}