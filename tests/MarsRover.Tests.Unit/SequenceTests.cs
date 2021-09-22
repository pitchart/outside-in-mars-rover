using FluentAssertions;
using MarsRover.Location;
using MarsRover.Movement;
using Xunit;

namespace MarsRover.Tests.Unit
{
    public class SequenceTests
    {
        [Fact]
        public void Should_retrieve_the_command_to_execute()
        {
            var sequence = Sequence.Initialize(new Coordinates(0, 0), Direction.East, "FFL");

            sequence.CurrentCommand.Should().Be('F');
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_be_complete_when_it_has_no_command_to_execute(string command)
        {
            var sequence = Sequence.Initialize(new Coordinates(0, 0), Direction.East, command);

            sequence.IsComplete().Should().Be(true);
        }

        [Fact]
        public void Should_not_be_complete_when_it_has_remaining_commands()
        {
            var sequence = Sequence.Initialize(new Coordinates(0, 0), Direction.East, "LFFR");

            sequence.IsComplete().Should().Be(false);
        }

        [Fact]
        public void Should_build_next_sequence()
        {
            var sequence = Sequence.Initialize(new Coordinates(0, 0), Direction.East, "LFFR");

            var next = sequence.NextStep(new Coordinates(0, 0), Direction.North);

            next.CurrentCommand.Should().Be('F');
        }
    }
}
