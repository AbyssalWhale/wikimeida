using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wikimediatests.Models.API.ResponseModels.Search.Pages;

namespace wikimediatests.Models.API.Routes
{
    internal class PagesRoute : ApiBaseModel
    {
        protected override string RouteUrl => "page";

        public PagesRoute(IAPIRequestContext requestContext) : base(requestContext)
        {
        }

        public async Task<IAPIResponse> GetPage(Page page)
        {
            var route = $"{RouteUrl}/{page.key}/bare";
            return await requestContext.GetAsync(url: route);
        }
    }
}
