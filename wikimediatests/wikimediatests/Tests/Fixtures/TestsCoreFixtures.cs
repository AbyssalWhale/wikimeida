using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Microsoft.VisualStudio.TestPlatform.Common;

namespace wikimediatests.Tests.Fixtures
{
    [TestFixture]
    public class TestsCoreFixtures
    {
        protected IPlaywright PlaywrightTests;
        protected IAPIRequestContext PlaywrightRequest;

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            // AKA GIVEN - A client of the API
            PlaywrightTests = await Playwright.CreateAsync();
            PlaywrightRequest = await PlaywrightTests.APIRequest.NewContextAsync(
                    new APIRequestNewContextOptions
                    {
                        BaseURL = "https://api.wikimedia.org/core/v1/wikipedia/en/"
                    }
                );
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await PlaywrightRequest.DisposeAsync();
        }
    }
}
