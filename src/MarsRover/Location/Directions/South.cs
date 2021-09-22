namespace MarsRover.Location.Directions
{
    internal class South : IDirection
    {
        public Direction Left => Direction.East;

        public Coordinates GoForward(Coordinates coordinates, Coordinates minCoordinates, Coordinates maxCoordinates)
        {
            return new Coordinates(coordinates.X, coordinates.Y <= minCoordinates.Y ? maxCoordinates.Y : coordinates.Y - 1);
        }

        public Direction Right => Direction.West;
    }
}