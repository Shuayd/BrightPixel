using System;
using NSubstitute;
using NUnit.Framework;
using SA.MarsRover.Models.Interfaces;
using SA.MarsRover.Models.Models;
using SLA.MarsRover.Services.Enums;
using SLA.MarsRover.Services.Interfaces;
using SLA.MarsRover.Services.Services;

namespace SA.MarsRover.Service.Tests.Services
{
    public class RoverServiceTests
    {
        private IRoverService _roverService;
        private IPlateau _plateau;
        private IPosition _position;

        [SetUp]
        public void Arrange()
        {
            _plateau = Substitute.For<IPlateau>();
            _position = Substitute.For<IPosition>();
        }

        [Test]
        public void Given_A_Rover_Out_Of_Borders_When_I_Call_Run_Should_Return_Message()
        {
            SetupRover(1, 2, Direction.N);
            const string input = "MMRMMRMRRMMRRMRMRMMMMMMRMMMM";

            var result = _roverService.Run(input);

            Assert.IsTrue(result.StartsWith("Rover outside the plateau"));
        }

        [Test]
        public void Given_A_Rover_When_I_Call_Run_Should_Return_Output_1_3_N()
        {
            SetupRover(1, 2, Direction.N);
            const string input = "LMLMLMLMM";

            var result = _roverService.Run(input);

            Assert.IsTrue(result.Equals("1 3 N"));
        }

        [Test]
        public void Given_A_Rover_When_I_Call_Run_Should_Return_Output_5_1_E()
        {
            SetupRover(3, 3, Direction.E);
            const string input = "MMRMMRMRRM";

            var result = _roverService.Run(input);

            Assert.IsTrue(result.Equals("5 1 E"));
        }

        [Test]
        public void Given_A_Rover_When_I_Call_Run_With_Incorrect_Directions_Should_Thorw_Exception()
        {
            SetupRover(3, 3, Direction.E);
            const string input = "SMLRRMMMM";

            Assert.Throws<ArgumentException>(() => _roverService.Run(input));
        }

        private void SetupRover(int x, int y, Direction direction)
        {
            _position.X = x;
            _position.Y = y;
            _plateau.Position.Returns(new Position(5, 5));
            _roverService = new RoverService(_position, _plateau, direction);
        }
    }
}
