using PoC.Simple;

namespace Owin
{
    public static class SimpleMiddlewareExtensions
    {
        public static void UseSimpleOwinMiddleware(this IAppBuilder app)
        {
            app.Use<SimpleOwinMiddleware>();
        }

        public static void UseSimpleExceptionMiddleware(this IAppBuilder app)
        {
            app.Use<SimpleExceptionMiddleware>();
        }
    }
}