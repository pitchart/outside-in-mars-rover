using MarsRover.Location;

namespace MarsRover.Movement.Moves
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
            return sequence.CurrentCommand == 'R';
        }

        public Sequence Move(Sequence sequence)
        {
            return sequence.NextStep(sequence.Coordinates, _map.GetRightOf(sequence.Direction));
        }
    }
}
