using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.AccessControl;
using System.Security.Cryptography;
using Algorithms;

namespace Tests
{
    public class PredicateEqualityAdapter<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _comparison;
        
        public PredicateEqualityAdapter(Func<T, T, bool> comparison)
        {
            _comparison = comparison;
        }

        public bool Equals(T x, T y)
        {
            return _comparison(x, y);
        }

        public int GetHashCode(T obj)
        {
            return 0;
        }
    }

    public static class LinqExtensions
    {
        public static IEnumerable<T> Intersect<T>(this IEnumerable<T> self
            , IEnumerable<T> other
            , Func<T, T, bool> comparison)
        {
            var comparer = new PredicateEqualityAdapter<T>(comparison);
            return self.Intersect(other, comparer);
        } 
    }

    public class Inning
    {
        public Inning()
        {
            this.PlayerAssignments = new List<PlayerAssignment>();
        }

        public List<PlayerAssignment> PlayerAssignments { get; set; }
        public bool Solvable { get; set; }

        private static bool CompareUsingMatches(PlayerAssignment left, PlayerAssignment right)
        {
            return left.Matches(right);
        }

        public bool CanBeAdjacentTo(Inning compare)
        {
            var intersection =
                PlayerAssignments.Intersect(compare.PlayerAssignments, CompareUsingMatches)
                    .Where(assigned => assigned.Position.HasValue == false);

            return !intersection.Any();
        }

        public bool CanBeInDirectSuccessionOf(Inning firstCompare, Inning secondCompare)
        {
            var inningIntersections = firstCompare.PlayerAssignments
                
                .Intersect(secondCompare.PlayerAssignments, CompareUsingMatches)
                .Intersect(this.PlayerAssignments, CompareUsingMatches)
                .Where(a => a.Position.HasValue)
                ;
            
            return !inningIntersections.Any();
        }
    }
}