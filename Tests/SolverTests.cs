using System;
using System.Linq;
using Algorithms;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    [TestFixture]
    public class SolverTests
    {
        public Solver Solver { get; set; }

        [SetUp]
        public void SetUp()
        {
            Solver = new Solver();
        }

        [Test]
        public void ProduceAnInning()
        {
            // Arrange

            // Act
            var inning = Solver.SolveInning();

            //Assert
            Assert.That(inning, Is.Not.Null);
        }

        [Test]
        public void ProduceAnInningThatHas16Players()
        {
            // Arrange

            // Act
            var inning = Solver.SolveInning();
            var fieldPositions = inning.PlayerAssignments;

            //Assert
            Assert.That(fieldPositions.Count, Is.EqualTo(16));
        }

        [Test]
        public void FieldedPositionsAreUnique()
        {
            // Arrange

            // Act
            var inning = Solver.SolveInning();
            var fieldedPositions = inning
                .PlayerAssignments
                .Where(x => x.Position.HasValue)
                .Select(x => x.Position.Value)
                .ToList()
                ;                

            // Assert
            var expected = fieldedPositions.Distinct().Count();
            Assert.That(fieldedPositions.Count, Is.EqualTo(expected));
        }

        [Test]
        public void AllPositionsAreFielded()
        {
            // Arrange
            var expected = Enum.GetValues(typeof (Position))
                                .Cast<Position>()
                                .ToList();

            // Act
            var inning = Solver.SolveInning();
            
            var fieldedPositions = inning
                .PlayerAssignments
                .Where(x => x.Position.HasValue)
                .Select(x => x.Position.Value)
                .ToList()
                ;

            // Assert
            Assert.That(fieldedPositions, Is.EqualTo(expected));
        }

    }
}