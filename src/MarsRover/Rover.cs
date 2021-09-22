using MarsRover.Location;
using MarsRover.Movement;

namespace MarsRover
{
    public class Rover
    {
        private Direction Direction { get; set; }

        private Coordinates Coordinates { get; set; }

        private readonly MoveHandler _moveHandler;

        public Rover(int x, int y, char direction, Map map)
        {
            Coordinates = new Coordinates(x, y);
            Direction = (Direction) direction;
            _moveHandler = new MoveHandler(map, new GoForward(map), new RotateLeft(map), new RotateRight(map));
        }

        public string Move(string commands)
        {
            var sequence = Sequence.Initialize(Coordinates, Direction, commands);

            while (!sequence.IsComplete())
            {
                sequence = Handle(sequence);
            }

            Coordinates = sequence.Coordinates;
            Direction = sequence.Direction;

            return ReportPosition(sequence);
        }

        private string ReportPosition(Sequence sequence)
        {
            return $"{Coordinates.X}:{Coordinates.Y}:{Direction.ToString()[0]}";
        }

        private Position Position()
        {
            return new Position(Coordinates, Direction);
        }

        private Sequence Handle(Sequence sequence)
        {
            return _moveHandler.Handle(sequence);
        }
    }
}
