using Microsoft.Owin;
using System;
using System.Text;
using System.Threading.Tasks;

namespace PoC.Simple
{
    public class SimpleExceptionMiddleware : OwinMiddleware
    {
        public SimpleExceptionMiddleware(OwinMiddleware next) : base(next) { }

        public async override Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
