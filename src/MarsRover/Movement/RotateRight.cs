using MarsRover.Location;

namespace MarsRover.Movement
{
    internal class RotateRight : IMovement
    {
        private readonly Map _map;

        public RotateRight(Map map)
        {
            _map = map;
        }

        public bool Supports(Sequence sequence)
        {
            return sequence.GetCommand() == 'R';
        }

        public Sequence Move(Sequence sequence)
        {
            return sequence.NextFrom(sequence.Coordinates, _map.GetRightOf(sequence.Direction));
        }
    }
}
