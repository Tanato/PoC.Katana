using Microsoft.Owin;
using System.Text;
using System.Threading.Tasks;

namespace PoC.Simple
{
    public class SimpleOwinMiddleware : OwinMiddleware
    {
        public SimpleOwinMiddleware(OwinMiddleware next) : base(next) { }

        public async override Task Invoke(IOwinContext context)
        {
            var bodyData = Encoding.UTF8.GetBytes("\n - Katana Middleware inbound!");
            await context.Response.Body.WriteAsync(bodyData, 0, bodyData.Length);

            await Next.Invoke(context);

            bodyData = Encoding.UTF8.GetBytes("\n - Katana Middleware outbound!");
            await context.Response.Body.WriteAsync(bodyData, 0, bodyData.Length);
        }
    }
}
