using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using Algorithms;

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
            var intersection =
                PlayerAssignments.Intersect(compare.PlayerAssignments)
                    .Where(assigned => assigned.Position.HasValue == false);

            return !intersection.Any();
        }

        public bool CanBeInDirectSuccessionOf(Inning firstCompare, Inning secondCompare)
        {
            var inningIntersections = firstCompare.PlayerAssignments
                .Intersect(secondCompare.PlayerAssignments)
                .Intersect(this.PlayerAssignments)
                .Where(a => a.Position.HasValue)
                ;
            
            return !inningIntersections.Any();
        }
    }
}