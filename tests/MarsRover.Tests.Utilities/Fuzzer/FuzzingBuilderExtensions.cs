using Diverse;
using MarsRover.Tests.Utilities.Builder;

namespace MarsRover.Tests.Utilities.Fuzzer
{
    public static class FuzzingBuilderExtensions
    {
        public static RoverBuilder Curiosity(this IFuzz fuzzer)
        {
            return RoverBuilder.Curiosity(fuzzer);
        }

        public static RoverBuilder ATestRover(this IFuzz fuzzer)
        {
            return RoverBuilder.TestRover(fuzzer);
        }
    }
}
