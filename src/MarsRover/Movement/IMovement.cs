namespace MarsRover.Movement
{
    internal interface IMovement
    {
        bool Supports(Sequence sequence);
        Sequence Move(Sequence sequence);
    }
}
