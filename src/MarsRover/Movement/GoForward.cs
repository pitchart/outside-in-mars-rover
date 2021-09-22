using MarsRover.Location;

namespace MarsRover.Movement
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
            return sequence.GetCommand() == 'F';
        }

        public Sequence Move(Sequence sequence)
        {
            var next = _map.GetNewCoordinates(sequence.Coordinates, sequence.Direction);

            return sequence.NextFrom(next, sequence.Direction);
        }
    }
}
