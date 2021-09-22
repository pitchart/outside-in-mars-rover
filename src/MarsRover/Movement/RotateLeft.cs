using MarsRover.Location;

namespace MarsRover.Movement
{
    internal class RotateLeft: IMovement
    {
        private readonly Map _map;

        public RotateLeft(Map map)
        {
            _map = map;
        }

        public bool Supports(Sequence sequence)
        {
            return sequence.CurrentCommand == 'L';
        }

        public Sequence Move(Sequence sequence)
        {
            return sequence.NextStep(sequence.Coordinates, _map.GetLeftOf(sequence.Direction));
        }
    }
}
