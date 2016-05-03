using SA.MarsRover.Models.Interfaces;

namespace SA.MarsRover.Models.Models
{
    public class Plateau : IPlateau
    {
        public Position Position { get; set; }

        public Plateau(Position position)
        {
            Position = position;
        }
    }
}
