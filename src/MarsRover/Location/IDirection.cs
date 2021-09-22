namespace MarsRover.Location
{
    interface IDirection
    {
        Coordinates GoForward(Coordinates coordinates, Coordinates minCoordinates, Coordinates maxCoordinates);
        Direction Right { get; }
        Direction Left { get; }
    }
}
