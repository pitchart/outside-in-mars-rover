using System.Collections.Generic;
using MarsRover.Location.Directions;

namespace MarsRover.Location
{
    public class Map
    {
        private readonly Coordinates _minCoordinates;
        private readonly Coordinates _maxCoordinates;
        private readonly List<IObstacle> _obstacles;

        public Map(Coordinates minCoordinates, Coordinates maxCoordinates, List<IObstacle> obstacles)
        {
            _minCoordinates = minCoordinates;
            _maxCoordinates = maxCoordinates;
            _obstacles = obstacles;
        }

        private readonly IDictionary<Direction, IDirection> _directions = new Dictionary<Direction, IDirection>
        {
            { Direction.North, new North() },
            { Direction.West, new West() },
            { Direction.South, new South() },
            { Direction.East, new East() }
        };

        internal Coordinates GetNewCoordinates(Coordinates coordinates, Direction direction)
        {
            return Directions(direction).GoForward(coordinates, _minCoordinates, _maxCoordinates);
        }

        private IDirection Directions(Direction direction)
        {
            return _directions[direction];
        }

        internal Direction GetRightOf(Direction direction)
        {
            return Directions(direction).Right;
        }

        internal Direction GetLeftOf(Direction direction)
        {
            return Directions(direction).Left;
        }
    }
}
