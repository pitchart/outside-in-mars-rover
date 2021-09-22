namespace MarsRover.Location.Directions
{
    internal class West : IDirection
    {
        public Coordinates GoForward(Coordinates coordinates, Coordinates minCoordinates, Coordinates maxCoordinates)
        {
            return new Coordinates(coordinates.X <= minCoordinates.X ? maxCoordinates.X : coordinates.X - 1, coordinates.Y);
        }

        public Direction Right => Direction.North;

        public Direction Left => Direction.South;
    }
}