using System.Net;
using wikimediatests.Models.API.Routes;
using wikimediatests.Tests.Fixtures;
using FluentAssertions;
using System.Text.Json;
using wikimediatests.Models.API.ResponseModels.Search.Pages;
using wikimediatests.Models.API.ResponseModels.Pages;

namespace wikimediatests.Tests.API
{
    public class Tests : TestsCoreFixtures
    {
        private SearchRoute SearchRoute;
        private static string QueryDefault = "furry rabbits";
        private SearchPageResultModel PagesFromSearchResult;

        [SetUp]
        public async Task Setup()
        {
            SearchRoute = new SearchRoute(requestContext: PlaywrightRequest);

            // WHEN - A search for pages containing for ‘furry rabbits’ is executed
            var requestResponse = await SearchRoute.GetSearchPageResult(query: QueryDefault);
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

        [Test]
        [TestCase("Sesame Street", "2023-08-17")]
        public async Task PageHasExpectedTimeStamp(string pageUnderTest, string expectedTimeStamp)
        {
            // GIVEN - The result for ‘furry rabbits’ search contains ‘Sesame Street’
            var pageSearchDetails = PagesFromSearchResult.pages.FirstOrDefault(p => p.title.Equals(pageUnderTest));
            pageSearchDetails.Should().NotBeNull();

            // WHEN - The page details for Sesame Street are requested
            var pageRoutes = new PagesRoute(requestContext: PlaywrightRequest);
            var pageRequestResponse = await pageRoutes.GetPage(page: pageSearchDetails);
            pageRequestResponse.StatusText.Should().Be(HttpStatusCode.OK.ToString());

            // THEN - It has a latest timestamp > 2023-08-17
            var requestResponseBody = pageRequestResponse.JsonAsync().Result;
            requestResponseBody.Should().NotBeNull();
            var pageDetails = requestResponseBody.Value.Deserialize<SinglePageDetails>();
            DateTime.TryParse(expectedTimeStamp, out var pageExpectedTime);
            pageDetails.latest.timestamp.Should().BeAfter(pageExpectedTime);
        }

        // Additional scenarious. Request type: GET Route: /core/v1/{project}/{language}/page/{title}/bare
        // Scenario 3. Send GET request where page title is LOWER case to check end point case sensetive. Based on requirements;
        // Scenario 4. Send GET request where page title is UPPER case to check end point case sensetive. Based on requirements;
        // Scenario 5. Send GET request where page title has spaces instead of underscores. Example: use - 'Sesame Street' and not 'Sesame_Street'. Check how route handles spaces;
        // Scenario 6. Send GET request where page title is SQL query to check basic vulnerability protection;
        // Scenario 7. Send GET request where page title is unknown/not existed page to check if route returns '404 Not found' response code with body that page, with requested title, does not exist
        // Scenario 8. Send GET request where page title is title of the page that was deleted. to check if route returns '404 Not found' response code with body that page, with requested title, does not exist
    }
}