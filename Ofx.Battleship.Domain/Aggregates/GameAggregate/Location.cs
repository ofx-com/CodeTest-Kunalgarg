using Ofx.Battleship.Domain.Common;

namespace Ofx.Battleship.Domain.Aggregates.GameAggregate
{
    public class Location: ValueObject
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
