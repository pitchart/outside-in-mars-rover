namespace MarsRover.Location.Directions
{
    internal class North : IDirection
    {
        public Direction Left => Direction.West;

        public Coordinates GoForward(Coordinates coordinates, Coordinates minCoordinates, Coordinates maxCoordinates)
        {
            return new Coordinates(coordinates.X, coordinates.Y >= maxCoordinates.Y ? minCoordinates.Y : coordinates.Y + 1);
        }

        public Direction Right => Direction.East;
    }
}