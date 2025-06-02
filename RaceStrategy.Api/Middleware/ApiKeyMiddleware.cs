using Microsoft.Extensions.Primitives;

namespace RaceStrategy.Api.Middleware
{
    public class ApiKeyMiddleware
    {
        private const string API_KEY = "ApiKey";
        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
        {
            StringValues apiKey;
            if (!context.Request.Headers.TryGetValue("X-API-KEY", out apiKey))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("No se envió la API-KEY");
                return;
            }

            var key = configuration.GetValue<string>(API_KEY);
            if (string.IsNullOrEmpty(key))
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("No se configuró la llave en la aplicación");
                return;
            }

            if (key != apiKey)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("No esta autenticado.");
                return;
            }

            await _next(context);
        }

    }
}
