using wikimediatests.Models.API.Routes;
using wikimediatests.Tests.Fixtures;

namespace wikimediatests.Tests.API
{
    public class Tests : TestsCoreFixtures
    {
        private SearchRoute SearchRoute;

        [SetUp]
        public async Task Setup()
        {
            SearchRoute = new SearchRoute(requestContext: PlaywrightRequest);
        }

        [Test]
        public async Task Test1()
        {
            var requestResponse = await SearchRoute.GetSearchPageResult();
            var body = await requestResponse.JsonAsync();
            await Console.Out.WriteLineAsync(body.ToString());
        }
    }
}