using NUnit.Framework;
using System.Collections.Concurrent;

namespace wikimediatests.Tests.Fixtures
{
    [TestFixture]
    public class TestsCoreFixtures
    {
        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            await Console.Out.WriteLineAsync("One time Set Up was executed");
        }
    }
}
