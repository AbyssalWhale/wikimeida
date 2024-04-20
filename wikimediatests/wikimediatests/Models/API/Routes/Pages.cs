using Microsoft.Playwright;

namespace wikimediatests.Models.API.Routes
{
    public class Pages : ApiBaseModel
    {
        protected override string RouteUrl => "";

        public Pages(IAPIRequestContext requestContext) : base(requestContext)
        {
        }
    }
}
