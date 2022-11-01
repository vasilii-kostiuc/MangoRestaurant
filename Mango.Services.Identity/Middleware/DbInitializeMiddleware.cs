using static Duende.IdentityServer.Models.IdentityResources;
using System.Net;
using Mango.Services.Identity.Initializer;

namespace Mango.Services.Identity.Middleware
{

    public class DbInitializeMiddleware
    {

        private readonly RequestDelegate _next;

        public DbInitializeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IDbInitializer dbInitializer)
        {
            dbInitializer.Initialize();
            await _next.Invoke(context);
        }
    }
       
}
