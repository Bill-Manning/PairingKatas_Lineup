using System.Collections.Generic;
using Algorithms;
using NUnit.Framework;

namespace Tests
{
    public class Inning
    {
        public List<PlayerAssignment> PlayerAssignments { get; set; }
        public bool Solvable { get; set; }
    }
}