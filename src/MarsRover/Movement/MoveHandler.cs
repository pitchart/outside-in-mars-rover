using System.Linq;
using MarsRover.Location;

namespace MarsRover.Movement
{
    internal class MoveHandler
    {
        private readonly IMovement[] _moves;

        public MoveHandler(Map map, params IMovement[] moves )
        {
            _moves = moves;
        }

        public Sequence Handle(Sequence sequence)
        {
            var move = _moves.FirstOrDefault(m => m.Supports(sequence));
            return move?.Move(sequence);
        }
    }
}
