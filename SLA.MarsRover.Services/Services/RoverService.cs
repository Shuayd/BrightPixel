using System;
using SA.MarsRover.Models.Interfaces;
using SLA.MarsRover.Services.Enums;
using SLA.MarsRover.Services.Interfaces;

namespace SLA.MarsRover.Services.Services
{
    public class RoverService : IRoverService
    {
        private IPosition _position;
        private IPlateau _plateau;
        private Direction _direction;

        public RoverService(IPosition position, IPlateau plateau, Direction direction)
        {
            _plateau = plateau;
            _position = position;
            _direction = direction;
        }

        public string Run(string input)
        {
            foreach (char letter in input)
            {
                switch (letter)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        Move();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid command value :{0}", letter));
                        break;
                }
            }

            string result = string.Format("{0} {1} {2}", _position.X, _position.Y, _direction);
            if (IsOutsideBoundary)
                result = "Rover outside the plateau";
            return result;
        }

        #region Helper Methods
        private void TurnLeft()
        {
            _direction = (_direction - 1) < Direction.N ? Direction.W : _direction - 1;
        }
        private void TurnRight()
        {
            _direction = (_direction + 1) > Direction.W ? Direction.N : _direction + 1;
        }
        private void Move()
        {
            if (_direction == Direction.N)
            {
                _position.Y++;
            }
            else if (_direction == Direction.E)
            {
                _position.X++;
            }
            else if (_direction == Direction.S)
            {
                _position.Y--;
            }
            else if (_direction == Direction.W)
            {
                _position.X--;
            }
        }

        private bool IsOutsideBoundary
        {
            get { return _position.X > _plateau.Position.X || _position.Y > _plateau.Position.Y; }
        }
        #endregion
    }
}
