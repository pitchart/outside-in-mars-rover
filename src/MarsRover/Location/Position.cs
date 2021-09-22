namespace MarsRover.Location
{
    internal class Position
    {
        public Coordinates Coordinates { get; }
        public Direction Direction { get; }

        public Position(Coordinates coordinates, Direction direction)
        {
            Coordinates = coordinates;
            Direction = direction;
        }
    }
}
