using System.Collections.Generic;
using Algorithms;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void AGameHasAvailablePlayers()
        {
            var game = new Game();

            Assert.That(game.AvailablePlayers, Is.InstanceOf<List<Player>>());
        }

        [Test]
        public void AGameHasANumberAndAnAOpponent()
        {
            var game = new Game();

            Assert.That(game.Number, Is.InstanceOf<int>());
            Assert.That(game.Opponent, Is.InstanceOf<string>());
        }

        [Test]
        public void AGameHasInnings()
        {
            var game = new Game();

            Assert.That(game.SolvedInnings, Is.InstanceOf<Inning[]>());
            Assert.That(game.SolvedInnings.Length, Is.EqualTo(7));
        }
    }
}