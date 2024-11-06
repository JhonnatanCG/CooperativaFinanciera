using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CooperativaFinanciera.Api.Common
{
    [AttributeUsage(validOn: AttributeTargets.Method | AttributeTargets.Class)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {

        private const string APIKEYHEADERNAME = "Ocp-Apim-Subscription-Key";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYHEADERNAME, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "ApiKey no se envió"
                };
                return;
            }
            var apiKey = Environment.GetEnvironmentVariable("APIKEY_HEADERVALUE") ??
                configuration.GetValue<string>("ApiKey:HeaderValue");
            if (!apiKey!.Equals(extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "ApiKey no es válida"
                };
                return;

            }
            await next();
        }
    }
}
