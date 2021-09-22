namespace MarsRover.Location.Directions
{
    internal class East : IDirection
    {
        public Direction Left => Direction.North;

        public Coordinates GoForward(Coordinates coordinates, Coordinates minCoordinates, Coordinates maxCoordinates)
        {
            return new Coordinates(coordinates.X >= maxCoordinates.X ? minCoordinates.X : coordinates.X + 1, coordinates.Y);
        }

        public Direction Right => Direction.South;
    }
}