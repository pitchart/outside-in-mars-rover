using Diverse;
using Xunit.Abstractions;

namespace MarsRover.Tests.Unit
{
    public class FuzzingTestCase
    {
        protected readonly Fuzzer _fuzzer;

        public FuzzingTestCase(ITestOutputHelper output)
        {
            Fuzzer.Log = s => output.WriteLine(s);
            _fuzzer = new Fuzzer();
        }

    }
}