namespace MarsRover.Location
{
    public interface IObstacle
    {
        bool Includes(Coordinates destination);
    }
}