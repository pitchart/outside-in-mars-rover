using FluentAssertions;
using MarsRover.Location;
using MarsRover.Tests.Utilities.Builder;
using MarsRover.Tests.Utilities.Fuzzer;
using Xunit;
using Xunit.Abstractions;

namespace MarsRover.Tests.Unit
{
    public class RoverTestsCase: FuzzingTestCase
    {
        public RoverTestsCase(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(default)]
        [InlineData("")]
        public void Should_not_move_when_receiving_null_command(string commands)
        {
            Rover rover = _fuzzer.ATestRover().LandedAt(0, 0).Facing('N').Build();

            string report = rover.Move(commands);

            report.Should().Be("0:0:N");
        }

        [Theory]
        [InlineData("F", "0:1:N")]
        [InlineData("FF", "0:2:N")]
        public void Should_move_forward_when_receiving_forward_command(string command, string position)
        {

            Rover rover = _fuzzer.ATestRover().LandedAt(0, 0).Facing('N').Build();

            string report = rover.Move(command);

            report.Should().Be(position);
        }

        [Theory]
        [InlineData('E', "3:2:E")]
        [InlineData('S', "2:1:S")]
        [InlineData('W', "1:2:W")]
        public void Should_move_forward_in_all_directions(char initialDirection, string expectedPosition)
        {
            Rover rover = _fuzzer.ATestRover().LandedAt(2, 2).Facing(initialDirection).Build();

            string report = rover.Move("F");

            report.Should().Be(expectedPosition);
        }

        [Theory]
        [InlineData("R", "0:0:E")]
        [InlineData("RR", "0:0:S")]
        [InlineData("RRR", "0:0:W")]
        [InlineData("RRRR", "0:0:N")]
        public void Should_turn_right_when_receiving_right_commands(string command, string position)
        {
            Rover rover = _fuzzer.ATestRover().LandedAt(0, 0).Facing('N').Build();

            string report = rover.Move(command);

            report.Should().Be(position);
        }

        [Theory]
        [InlineData("L", "0:0:W")]
        [InlineData("LL", "0:0:S")]
        [InlineData("LLL", "0:0:E")]
        [InlineData("LLLL", "0:0:N")]
        public void Should_turn_left_when_receiving_left_commands(string command, string position)
        {
            Rover rover = _fuzzer.ATestRover().LandedAt(0, 0).Facing('N').Build();

            string report = rover.Move(command);

            report.Should().Be(position);
        }

        [Theory]
        [InlineData("F", "0:0:N")]
        [InlineData("FF", "0:1:N")]
        [InlineData("FFFFFF", "0:0:N")]
        public void Should_not_leave_the_map_when_crossing_edge_and_moving_forward(string command, string position)
        {
            Rover rover = _fuzzer.ATestRover().LandedAt(0, 4).Facing('N').Build();

            string report = rover.Move(command);

            report.Should().Be(position);
        }

        [Theory]
        [InlineData("F", "0:0:E")]
        [InlineData("FF", "1:0:E")]
        [InlineData("FFFFF", "4:0:E")]
        public void Should_not_leave_grid_when_crossing_edge_and_moving_forward_facing_east(string command, string position)
        {
            Rover rover = _fuzzer.ATestRover().LandedAt(4, 0).Facing('E').Build();

            string report = rover.Move(command);

            report.Should().Be(position);
        }

        [Theory]
        [InlineData("F", "0:4:S")]
        [InlineData("FF", "0:3:S")]
        [InlineData("FFFFF", "0:0:S")]
        public void Should_not_leave_grid_when_crossing_edge_and_moving_forward_facing_south(string command, string position)
        {
            Rover rover = _fuzzer.ATestRover().LandedAt(0, 0).Facing('S').Build();

            string report = rover.Move(command);

            report.Should().Be(position);
        }

        [Theory]
        [InlineData("F", "4:0:W")]
        [InlineData("FF", "3:0:W")]
        [InlineData("FFFFF", "0:0:W")]
        public void Should_not_leave_grid_when_crossing_edge_and_moving_forward_facing_west(string command, string position)
        {
            Rover rover = _fuzzer.ATestRover().LandedAt(0, 0).Facing('W').Build();

            string report = rover.Move(command);

            report.Should().Be(position);
        }

    }
}
