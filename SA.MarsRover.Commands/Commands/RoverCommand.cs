using SA.MarsRover.Commands.Interfaces;
using SLA.MarsRover.Services.Interfaces;

namespace SA.MarsRover.Commands.Commands
{
    public class RoverCommand : IRoverCommand
    {
        private IRoverService _roverService;

        public RoverCommand(IRoverService roverService)
        {
            _roverService = roverService;
        }

        public dynamic Start(string input)
        {
            return _roverService.Run(input);
        }
    }
}
