using wikimediatests.Tests.Fixtures;

namespace wikimediatests.Tests.API
{
    public class Tests : TestsCoreFixtures
    {
        [SetUp]
        public async Task Setup()
        {
            await Console.Out.WriteLineAsync("Set Up was executed");
        }

        [Test]
        public async Task Test1()
        {
            await Console.Out.WriteLineAsync("Test was executed");
        }
    }
}