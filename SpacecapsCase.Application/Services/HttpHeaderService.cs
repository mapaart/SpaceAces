using Microsoft.AspNetCore.Http;
using SpacecapsCase.Application.Interfaces;

namespace SpacecapsCase.Application.Services
{
    public class HttpHeaderService : IHttpHeaderService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpHeaderService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetHeaderValue(string headerName)
        {
            return _httpContextAccessor.HttpContext.Request.Headers[headerName];
        }
    }
}