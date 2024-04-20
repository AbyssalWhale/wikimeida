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

        [SetUp]
        public async Task Setup()
        {
            SearchRoute = new SearchRoute(requestContext: PlaywrightRequest);
        }

        [Test]
        [TestCase("furry rabbits", "Sesame Street")]
        public async Task PageWithTitleCanBeFound(string query, string expectedPageToExist)
        {
            // WHEN - A search for pages containing for ‘furry rabbits’ is executed
            var requestResponse = await SearchRoute.GetSearchPageResult(query: query);
            requestResponse.StatusText.Should().Be(HttpStatusCode.OK.ToString());
            var requestResponseBody = requestResponse.JsonAsync().Result;
            requestResponseBody.Should().NotBeNull();
            var responsePages = requestResponseBody.Value.Deserialize<SearchPageResultModel>();
            responsePages.Should().NotBeNull();

            // THEN - A page with the title ‘Sesame Street’ is found
            var isContainingPage = responsePages.pages.Any(p => p.title.Equals(expectedPageToExist));
            isContainingPage.Should().BeTrue();

        }
    }
}