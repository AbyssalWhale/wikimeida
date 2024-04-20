using System.Net;
using wikimediatests.Models.API.Routes;
using wikimediatests.Tests.Fixtures;
using FluentAssertions;
using System.Text.Json;
using wikimediatests.Models.API.ResponseModels.Search.Pages;

namespace wikimediatests.Tests.API
{
    public class Tests : TestsCoreFixtures
    {
        private SearchRoute SearchRoute;
        private static string DefaultQueru = "furry rabbits";
        private SearchPageResultModel PagesFromSearchResult;

        [SetUp]
        public async Task Setup()
        {
            SearchRoute = new SearchRoute(requestContext: PlaywrightRequest);

            // WHEN - A search for pages containing for ‘furry rabbits’ is executed
            var requestResponse = await SearchRoute.GetSearchPageResult(query: DefaultQueru);
            requestResponse.StatusText.Should().Be(HttpStatusCode.OK.ToString());

            var requestResponseBody = requestResponse.JsonAsync().Result;
            requestResponseBody.Should().NotBeNull();
            PagesFromSearchResult = requestResponseBody.Value.Deserialize<SearchPageResultModel>();
            PagesFromSearchResult.Should().NotBeNull();
        }

        [Test]
        [TestCase("Sesame Street")]
        public async Task PageWithTitleCanBeFound(string expectedPageToExist)
        {
            // THEN - A page with the title ‘Sesame Street’ is found
            var isContainingPage = PagesFromSearchResult.pages.Any(p => p.title.Equals(expectedPageToExist));
            isContainingPage.Should().BeTrue();
        }
    }
}