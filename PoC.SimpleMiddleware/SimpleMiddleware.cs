using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PoC.Simple
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class SimpleMiddleware
    {
        private AppFunc next;

        public SimpleMiddleware(AppFunc next)
        {
            this.next = next;
        }

        public async Task Invoke(IDictionary<string, object> context)
        {
            // Faz algum processamento ("inbound")...
            var responseBody = (Stream)context["owin.ResponseBody"];

            var bodyData = Encoding.UTF8.GetBytes("\n - Simple Middleware inbound!");
            await responseBody.WriteAsync(bodyData, 0, bodyData.Length);

            await next.Invoke(context);

            bodyData = Encoding.UTF8.GetBytes("\n - Simple Middleware outbound!");
            await responseBody.WriteAsync(bodyData, 0, bodyData.Length);
        }
    }
}
