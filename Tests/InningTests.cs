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
            var assignment = new PlayerAssignment
            {
                Player = new Player
                {
                    Name = "Billy",
                    Gender = Gender.Male
                },
                Position = null
            };

            var inning1 = new Inning()
            {
                PlayerAssignments = {assignment},
            };
            var inning2 = new Inning()
            {
                PlayerAssignments = {assignment}
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
            var inning3 = new Inning()
            {
                PlayerAssignments = { assignment }
            };

            var result = inning3.CanBeInDirectSuccessionOf(inning1, inning2);
            result.ShouldBe(false);
        }

        [Test]
        public void CanBeAdjacentTo_TrueWhenPlayerDoesNotFieldSamePositionThreeInningsInARow()
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
    }
}