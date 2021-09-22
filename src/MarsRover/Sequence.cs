using System.Linq;
using MarsRover.Location;

namespace MarsRover
{
    public class Sequence
    {
        private readonly Position _position;
        private readonly string _commands;

        public Coordinates Coordinates => _position.Coordinates;

        public Direction Direction => _position.Direction;

        public char CurrentCommand => _commands[0];

        private Sequence(Position position, string commands)
        {
            _position = position;
            _commands = commands;
        }

        public static Sequence Initialize(Coordinates coordinates, Direction direction, string commands)
        {
            return new Sequence(new Position(coordinates, direction), commands);
        }

        public Sequence NextStep(Coordinates coordinates, Direction direction)
        {
            return new Sequence(new Position(coordinates, direction), RemainingCommands());
        }

        private string RemainingCommands()
        {
            return string.Join("", _commands.Skip(1));
        }

        public bool IsComplete()
        {
            return string.IsNullOrEmpty(_commands);
        }
    }
}
