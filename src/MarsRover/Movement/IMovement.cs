namespace MarsRover
{
    internal interface IMovement
    {
        bool Supports(Sequence sequence);
        Sequence Move(Sequence sequence);
    }
}
