using System;
using FluentAssertions;
using MarsRover.Tests.Utilities.Builder;
using TechTalk.SpecFlow;

namespace MarsRover.Tests.Acceptance.Steps
{
    [Binding]
    public sealed class RoverStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private RoverBuilder _builder;
        private string _report;

        public RoverStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the (rover .*) (?:is|has landed) on (.*) at coordinates \((.*), (.*)\) (facing .*)")]
        [Given(@"the (.* rover) is at (.*) at coordinates \((.*), (.*)\) (facing .*)")]
        public void GivenTheRoverIsAtAtCoordinatesFacing(RoverBuilder roverBuilder, string planet, int x, int y, char direction)
        {
            _builder = roverBuilder.LandedAt(x, y).Facing(direction);
        }

        //[Given(@"a rock is known at \((.*), (.*)\)")]
        //public void GivenARockIsKnownAt(int x, int y)
        //{
        //    var mars = MapBuilder.ForMars().WithObstacleAt(x, y).Build();
        //    _builder.NavigatingOn(mars);
        //}

        //[Given(@"a crater is known from \((.*), (.*)\) to \((.*), (.*)\)")]
        //public void GivenACraterIsKnownFromTo(int p0, int p1, int p2, int p3)
        //{
        //    var mars = MapBuilder.ForMars().WithSquareObstacle(@from: (p0, p1), to: (p2, p3)).Build();
        //    _builder.NavigatingOn(mars);
        //}

        [When(@"a team member sends command '(.*)'")]
        public void WhenATeamMemberSendsItCommand(string command)
        {
            _report = _builder.Build().Move(command);
        }

        [Then(@"the rover signals its position at \((.*), (.*)\) (facing .*)")]
        public void ThenTheRoverSignalsItsPositionAtFacing(int x, int y, char direction)
        {
            _report.Should().Be($"{x}:{y}:{direction}");
        }

        [Then(@"the rover reports (.*)")]
        public void ThenTheRoverReports(string anError)
        {
            var errorPrefix = ArgumentsBinding.ErrorTypeToPrefix(anError);
            _report.Should().StartWith(errorPrefix);
        }

        [Then(@"signals its position at \((.*), (.*)\) (facing .*)")]
        public void ThenSignalsItsPositionAtFacing(int x, int y, char direction)
        {
            _report.Should().EndWith($"{x}:{y}:{direction}");
        }
    }
}
