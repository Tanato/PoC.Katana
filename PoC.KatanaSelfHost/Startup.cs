using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PoC.Simple;

namespace PoC.KatanaSelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseSimpleExceptionMiddleware();
            app.Use<SimpleMiddleware>();
            app.UseSimpleOwinMiddleware();

            app.Run(async (context) =>
            {
                var bodyData = Encoding.UTF8.GetBytes("\n - Run baby, run!");
                await context.Response.Body.WriteAsync(bodyData, 0, bodyData.Length);
            });
        }
    }
}
