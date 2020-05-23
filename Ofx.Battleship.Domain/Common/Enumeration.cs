
namespace Ofx.Battleship.Domain.Common
{
    public abstract class Enumeration 
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
