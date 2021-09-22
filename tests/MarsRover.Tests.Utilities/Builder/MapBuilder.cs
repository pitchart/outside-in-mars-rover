using System.Collections.Generic;
using MarsRover.Location;

namespace MarsRover.Tests.Utilities.Builder
{
    public class MapBuilder
    {
        private Coordinates _min;

        private Coordinates _max;
        private List<IObstacle> _obstacles = new List<IObstacle>();

        private MapBuilder(Coordinates min, Coordinates max)
        {
            _min = min;
            _max = max;
        }

        public static MapBuilder ForChileHighDesert()
        {
            return new MapBuilder(new Coordinates(0, 0), new Coordinates(4, 4));
        }

        public static MapBuilder ForMars()
        {
            return new MapBuilder(new Coordinates(-180, -180), new Coordinates(180, 180));
        }

        public Map Build()
        {
            return new Map(this._min, this._max, _obstacles);
        }

        //public MapBuilder WithObstacleAt(int x, int y)
        //{
        //    _obstacles.Add(new Obstacle(x, y));
        //    return this;
        //}

        private Coordinates ToCoordinates((int p0, int p1) @from)
        {
            return new Coordinates(@from.p0, @from.p1);
        }
    }
}
