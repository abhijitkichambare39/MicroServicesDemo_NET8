
using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace Mango.Services.OrderAPI.Utility
{
    //deligating handler are of similar to dot netcore middleware 
    //main difference are on clientside
    //if user making httprequest to httpclient we can leverage to pass the bearer token to other request
    public class BackendApiAuthenticationHttpClientHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _accessor;

        public BackendApiAuthenticationHttpClientHandler(IHttpContextAccessor httpContextAccessor)
        {
            _accessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _accessor.HttpContext.GetTokenAsync("access_token");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken);
        }

    }
}
