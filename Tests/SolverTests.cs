using System;
using System.Collections.Generic;
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
        public List<Player> AvailablePlayersList { get; set; }

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
            var inning = Solver.SolveInning(AvailablePlayersList);

            //Assert
            Assert.That(inning, Is.Not.Null);
        }

        [TestCase(16)]
        [TestCase(200)]
        [TestCase(10)]
        public void ProduceAnInningThatHasAnAssignedPlayerForEachOnePassedIn(int playerCount)
        {
            AvailablePlayersList = Enumerable.Range(1, playerCount).Select(a => new Player { Name = $"Player {a}", Gender = (Gender)(a%2) }).ToList();
            // Arrange

            // Act
            var inning = Solver.SolveInning(AvailablePlayersList);
            var fieldPositions = inning.PlayerAssignments;

            //Assert
            Assert.That(fieldPositions.Count, Is.EqualTo(playerCount));
        }

        [TestCase(9)]
        [TestCase(6)]
        public void ProduceAnInningThatIsNotSolvableWhenLessThan10PlayersAreProvided(int playerCount)
        {
            AvailablePlayersList = Enumerable.Range(1, playerCount).Select(a => new Player { Name = $"Player {a}" }).ToList();
            // Arrange

            // Act
            var inning = Solver.SolveInning(AvailablePlayersList);
            
            //Assert
            Assert.That(inning.Solvable, Is.False);
        }

        [TestCase(Gender.Male)]
        [TestCase(Gender.Female)]
        public void ProduceAnInningWhenLessThan3OfEitherGenderAreProvided(Gender g)
        {
            AvailablePlayersList = Enumerable.Range(1, 10).Select(a => new Player { Name = $"Player {a}", Gender = g }).ToList();
            // Act
            var inning = Solver.SolveInning(AvailablePlayersList);

            //Assert
            Assert.That(inning.Solvable, Is.False);
        }

        [Test]
        public void FieldedPositionsAreUnique()
        {
            AvailablePlayersList = Enumerable.Range(1, 16).Select(a => new Player { Name = $"Player {a}", Gender = (Gender)(a % 2) }).ToList();
            // Arrange

            // Act
            var inning = Solver.SolveInning(AvailablePlayersList);
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
            AvailablePlayersList = Enumerable.Range(1, 16).Select(a => new Player { Name = $"Player {a}", Gender = (Gender)(a % 2) }).ToList();


            // Act
            var inning = Solver.SolveInning(AvailablePlayersList);
            
            var fieldedPositions = inning
                .PlayerAssignments
                .Where(x => x.Position.HasValue)
                .Select(x => x.Position.Value)
                .ToList()
                ;

            // Assert
            Assert.That(fieldedPositions, Is.EqualTo(expected));
        }

        [Test]
        public void PlayersPassedInAreTheOnesSelected()
        {
            AvailablePlayersList = Enumerable.Range(1, 16).Select(a => new Player { Name = $"Player {a}", Gender = (Gender)(a % 2) }).ToList();

            var inning = Solver.SolveInning(AvailablePlayersList);

            Assert.That(inning.PlayerAssignments.Select(a => a.Player), 
                            Is.SubsetOf(AvailablePlayersList));
        }

        [Test]
        public void InningUnsolvableWhenGivenNoAvailablePlayers()
        {
            var availablePlayersList = new List<Player>();
            var inning = Solver.SolveInning(availablePlayersList);

            Assert.That(inning.Solvable, Is.False);
        }


        [Test]
        public void SolveGameReturnsAGame()
        {

            // Act
            var game = Solver.SolveGame(AvailablePlayersList);

            //Assert
            Assert.That(game, Is.Not.Null);
            Assert.That(game, Is.InstanceOf<Game>());

        }

        [TestCase(1)]
        [TestCase(16)]
        [TestCase(4096)]
        public void SolveGameReturnsAGameWithCorrectNumberPlayers(int playerCount)
        {
            //Arrange
            AvailablePlayersList = Enumerable.Range(1, playerCount)
                .Select(a => new Player { Name = $"Player {a}", Gender = (Gender)(a % 2) })
                .ToList();


            //Act
            var game = Solver.SolveGame(AvailablePlayersList);

            //Assert
            Assert.That(game.AvailablePlayers.Count, Is.EqualTo(playerCount));
        }

        [Test]
        public void SolveGameReturnsAGameWithPlayersFromAvailableInEachInning()
        {
            //Arrange
            AvailablePlayersList = Enumerable.Range(1, 10)
                .Select(a => new Player { Name = $"Player {a}", Gender = (Gender)(a % 2) })
                .ToList();


            //Act
            var game = Solver.SolveGame(AvailablePlayersList);
            
            //Assert
            foreach (var inning in game.SolvedInnings)
            {
                foreach (var playerAssignment in inning.PlayerAssignments)
                {
                    Assert.That(AvailablePlayersList.Contains(playerAssignment.Player));
                }
            }
        }

        [Test]
        public void SolveGameReturnsInningsThatCanBeAdjacentToOneAnother()
        {

            //Arrange
            AvailablePlayersList = Enumerable.Range(1, 12)
                .Select(a => new Player { Name = $"Player {a}", Gender = (Gender)(a % 2) })
                .ToList();

            //Act
            var game = Solver.SolveGame(AvailablePlayersList);

            //Assert
            for (int i = 0; i < 6; i++)
            {
                Assert.That(game.SolvedInnings[i].CanBeAdjacentTo(game.SolvedInnings[i + 1]));
            }
        }

        [Test]
        public void SolveGameReturnsInningsThatDontHaveTheSamePlayersPlayingTheSamePositionThreeInningsInARow()
        {
            Assert.Fail();
        }
    }
}