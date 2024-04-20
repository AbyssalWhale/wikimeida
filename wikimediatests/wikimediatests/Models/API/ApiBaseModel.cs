using Microsoft.Playwright;

namespace wikimediatests.Models.API
{
    public abstract class ApiBaseModel
    {
        private IAPIRequestContext requestContext;
        protected abstract string RouteUrl { get; }

        public ApiBaseModel(IAPIRequestContext requestContext) 
        {
            this.requestContext = requestContext;
        }
    }
}
