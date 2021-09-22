using System;
using MarsRover.Tests.Utilities.Builder;
using TechTalk.SpecFlow;

namespace MarsRover.Tests.Acceptance.Steps
{
    [Binding]
    public class ArgumentsBinding
    {
        [StepArgumentTransformation(@"rover (\w+)")]
        [StepArgumentTransformation(@"(\w+) rover")]
        public RoverBuilder RoverNameToBuilder(string name)
        {
            return name switch
            {
                "curiosity" => RoverBuilder.Curiosity(),
                "test" => RoverBuilder.TestRover(),
                _ => throw new ArgumentOutOfRangeException(nameof(name), name, null)
            };
        }

        [StepArgumentTransformation(@"facing (.*)")]
        public char StringToCharDirection(string name)
        {
            return name switch
            {
                "North" => 'N',
                "East" => 'E',
                "South" => 'S',
                "West" => 'W',
                _ => throw new ArgumentOutOfRangeException(nameof(name), name, null)
            };
        }

        internal  static string ErrorTypeToPrefix(string errorType)
        {
            return errorType switch
            {
                "an error" => "E:",
                "an obstacle" => "O:",
                _ => throw new ArgumentOutOfRangeException(nameof(errorType), errorType, null)
            };
        }
    }
}
