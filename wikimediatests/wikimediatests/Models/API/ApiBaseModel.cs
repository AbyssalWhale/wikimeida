using Microsoft.Playwright;

namespace wikimediatests.Models.API
{
    public abstract class ApiBaseModel
    {
        protected IAPIRequestContext requestContext;
        protected abstract string RouteUrl { get; }

        public ApiBaseModel(IAPIRequestContext requestContext) 
        {
            this.requestContext = requestContext;
        }
    }
}
