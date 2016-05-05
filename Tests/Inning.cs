using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text.RegularExpressions;
using Algorithms;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal.Builders;
using Shouldly;

namespace Tests
{
    public class Inning
    {
        public Inning()
        {
            this.PlayerAssignments = new List<PlayerAssignment>();
        }

        public List<PlayerAssignment> PlayerAssignments { get; set; }
        public bool Solvable { get; set; }

        public bool CanBeAdjacentTo(Inning compare)
        {
            var benchedPlayers = PlayerAssignments.Where(assigned => assigned.Position.HasValue == false);
            var comparedBenchedPlayers = compare.PlayerAssignments.Where(assigned => assigned.Position.HasValue == false);

            return !benchedPlayers
                        .Any(pa => comparedBenchedPlayers
                                    .Any(cpa => cpa.Matches(pa)));
        }
    }
}