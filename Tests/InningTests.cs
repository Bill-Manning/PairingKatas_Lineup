using Algorithms;
using FizzWare.NBuilder;
using NUnit.Framework;
using Shouldly;

namespace Tests
{
    [TestFixture]
    public class InningTests
    {
        [Test] 
        public void CanBeAdjacentTo_WhenNoPlayers()
        {
            var inning1 = new Inning();
            var inning2 = new Inning();

            var result = inning1.CanBeAdjacentTo(inning2);

            result.ShouldBe(true);
        }

        [Test]
        public void CannotBeAdjacentTo_WhenSamePlayerIsBenched()
        {
            var inning1 = new Inning()
            {
                PlayerAssignments = {CreatePlayerAssignmentFor("Billy", null)},
            };
            var inning2 = new Inning()
            {
                PlayerAssignments = { CreatePlayerAssignmentFor("Billy", null) }
            };

            var result = inning1.CanBeAdjacentTo(inning2);
            result.ShouldBe(false);
        }

        [Test]
        public void CanBeAdjacentTo_WhenSamePlayerOccupiesSamePosition()
        {
            var assignment = new PlayerAssignment
            {
                Player = new Player
                {
                    Name = "Billy",
                    Gender = Gender.Male
                },
                Position = Position.Catcher
            };

            var inning1 = new Inning()
            {
                PlayerAssignments = { assignment },
            };
            var inning2 = new Inning()
            {
                PlayerAssignments = { assignment }
            };

            var result = inning1.CanBeAdjacentTo(inning2);
            result.ShouldBe(true);
        }

        [Test]
        public void CanBeAdjacentTo_FalseWhenPlayerFieldsSamePositionThreeInningsInARow()
        {
            var inning1 = new Inning()
            {
                PlayerAssignments = { CreatePlayerAssignmentFor("Billy") },
            };
            var inning2 = new Inning()
            {
                PlayerAssignments = { CreatePlayerAssignmentFor("Billy") }
            };
            var inning3 = new Inning()
            {
                PlayerAssignments = { CreatePlayerAssignmentFor("Billy") }
            };

            var result = inning3.CanBeInDirectSuccessionOf(inning1, inning2);
            result.ShouldBe(false);
        }

        [Test]
        public void CanBeAdjacentTo_TrueWhenPlayerDoesNotFieldSamePositionThreeInningsInARow()
        {
            var inning1 = new Inning()
            {
                PlayerAssignments = { CreatePlayerAssignmentFor("Billy") },
            };
            var inning2 = new Inning()
            {
                PlayerAssignments = { CreatePlayerAssignmentFor("Billy") }
            };
            var secondAssignment = new PlayerAssignment
            {
                Player = new Player
                {
                    Name = "Billy",
                    Gender = Gender.Male
                },
                Position = Position.FirstBase
            };

            var inning3 = new Inning()
            {
                PlayerAssignments = { secondAssignment }
            };

            var result = inning3.CanBeInDirectSuccessionOf(inning1, inning2);
            result.ShouldBe(true);
        }

        private static PlayerAssignment CreatePlayerAssignmentFor(
            string playerName, 
            Position? position = Position.Catcher)
        {
            var assignment = new PlayerAssignment
            {
                Player = new Player
                {
                    Name = playerName,
                    Gender = Gender.Male
                },
                Position = position
            };
            return assignment;
        }
    }
}