using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace WebAPI.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        // TİPS = readonly amaç sadece değer atama

        public AuthorizationMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Path.HasValue)
            {
                var path = httpContext.Request.Path.Value;
                // /api/Brand/GetAll

                if (path.StartsWith("/api/auth/", StringComparison.InvariantCultureIgnoreCase))
                {
                    await _next(httpContext);
                    return;
                }

                if (httpContext.User.Identity.IsAuthenticated && httpContext.User.IsInRole(path))
                {
                    await _next(httpContext);
                    return;
                }
            }
            httpContext.Response.StatusCode = 403;

            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorResult("Erişim Engellendi")));

            //httpContext.Response.ContentType = "text/html";
            //await httpContext.Response.WriteAsync("<b style='color:red'>erişim engellendi</b>");
        }
    }
}
