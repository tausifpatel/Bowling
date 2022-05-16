using System;
using bawling;
using FluentAssertions;
using Xunit;

namespace Bawling.tests
{
    public class UnitTest1
    {
        private readonly BawlingScore _bawlingScore;

        public UnitTest1()
        {
            _bawlingScore = new BawlingScore();
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("53", 8)]
        [InlineData("22 22", 8)]
        [InlineData("X 22", 18)]
        [InlineData("X 11 22", 18)]
        [InlineData("4/ 32", 18)]
        [InlineData("X 45 4/ 32", 46)]
        [InlineData("65 X 43 72", 44)]
        [InlineData("X 6/ 56 45", 55)]
        [InlineData("X X 55 33", 56)]
        [InlineData("54 81 45 X 37", 57)]
        [InlineData("4/ 5/ 11", 28)]
        [InlineData("4/ 5/ 11 X 61", 52)]
        [InlineData("6/ X 11", 34)]
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5", 150)]
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/X", 155)]
        public void ReturnsCorrectScore(string rolls, double score)
        {
            var result = _bawlingScore.Calculate(rolls);

            result.Should().Be(score);
        }
    }
}
