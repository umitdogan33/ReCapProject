using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Middlewares
{
    public static class AuthorizationMiddlewareExtensions
    {
        public static void ConfigreAuthorization(this IApplicationBuilder app)
        {
            app.UseMiddleware<AuthorizationMiddleware>();
        }
    }
}
