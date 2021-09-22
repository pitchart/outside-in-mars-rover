using Diverse;
using MarsRover.Location;

namespace MarsRover.Tests.Utilities.Builder
{
    public class RoverBuilder
    {
        private Coordinates _initialCoordinates;
        private char _direction;
        private Map _map;
        private readonly IFuzz _fuzzer;

        private RoverBuilder(IFuzz fuzzer)
        {
            _fuzzer = fuzzer;
        }

        private RoverBuilder()
        {

        }

        public static RoverBuilder TestRover()
        {
            return new RoverBuilder()
            {
                _initialCoordinates = new Coordinates(0, 0),
                _direction = 'N',
                _map = MapBuilder.ForChileHighDesert().Build(),
            };
        }

        public static RoverBuilder Curiosity()
        {
            return new RoverBuilder()
            {
                _initialCoordinates = new Coordinates(0, 0),
                _direction = 'N',
                _map = MapBuilder.ForMars().Build(),
            };
        }

        public static RoverBuilder TestRover(IFuzz fuzzer)
        {
            return new RoverBuilder(fuzzer)
            {
                _initialCoordinates = new Coordinates(fuzzer.GenerateInteger(minValue: 0, maxValue:4), fuzzer.GenerateInteger(minValue: 0, maxValue:4)),
                _direction = fuzzer.PickOneFrom(new[] {'N', 'S', 'E', 'W'}),
                _map = MapBuilder.ForChileHighDesert().Build(),
            };
        }

        public static RoverBuilder Curiosity(IFuzz fuzzer)
        {
            return new RoverBuilder(fuzzer)
            {
                _initialCoordinates = new Coordinates(0, 0),
                _direction = fuzzer.PickOneFrom(new char[] {'N', 'S', 'E', 'W'}),
                _map = MapBuilder.ForMars().Build(),
            };
        }

        public RoverBuilder LandedAt(int x, int y)
        {
            _initialCoordinates = new Coordinates(x, y);
            return this;
        }

        public RoverBuilder Facing(char direction)
        {
            _direction = direction;
            return this;
        }


        public RoverBuilder NavigatingOn(Map map)
        {
            _map = map;
            return this;
        }

        public Rover Build()
        {
            return new Rover(_initialCoordinates.X, _initialCoordinates.Y, _direction, _map);
        }
    }
}
