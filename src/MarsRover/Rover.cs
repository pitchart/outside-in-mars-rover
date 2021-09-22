using MarsRover.Location;
using MarsRover.Movement;
using MarsRover.Movement.Moves;

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
                sequence = Next(sequence);
            }

            Coordinates = sequence.Coordinates;
            Direction = sequence.Direction;

            return ReportPosition(sequence);
        }

        private string ReportPosition(Sequence sequence)
        {
            return $"{sequence.Coordinates.X}:{sequence.Coordinates.Y}:{sequence.Direction.ToString()[0]}";
        }

        private Sequence Next(Sequence sequence)
        {
            return _moveHandler.Handle(sequence);
        }
    }
}
