using MarsRover.Location;

namespace MarsRover.Movement.Moves
{
    internal class GoForward: IMovement
    {
        private readonly Map _map;

        public GoForward(Map map)
        {
            _map = map;
        }

        public bool Supports(Sequence sequence)
        {
            return sequence.CurrentCommand == 'F';
        }

        public Sequence Move(Sequence sequence)
        {
            var next = _map.GetDestination(sequence.Coordinates, sequence.Direction);

            return sequence.NextStep(next, sequence.Direction);
        }
    }
}
