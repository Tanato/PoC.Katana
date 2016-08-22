using Microsoft.Owin.Hosting;
using PoC.KatanaSelfHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace PoC.KatanaSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(config =>
            {
                config.Service<HostService>(instance =>
                {
                    instance.ConstructUsing(() => new HostService());

                    instance.WhenStarted(a => a.Start());
                    instance.WhenStopped(a => a.Stop());
                });

                config.SetDisplayName("PoC Katana Self Host");
                config.SetServiceName("PoCKatanaSelfHost");
                config.SetDescription("PoC de Katana com Self Host");

                config.RunAsNetworkService();
            });
        }
    }
}
