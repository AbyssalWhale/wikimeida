using Microsoft.Playwright;

namespace wikimediatests.Models.API.Routes
{
    public class SearchRoute : ApiBaseModel
    {
        protected override string RouteUrl => "search";

        public SearchRoute(IAPIRequestContext requestContext) : base(requestContext)
        {
        }

        public async Task<IAPIResponse> GetSearchPageResult(string query = "earth")
        {
            var route = $"{RouteUrl}/page?q={query}";
            return await requestContext.GetAsync(url: route);
        }
    }
}
