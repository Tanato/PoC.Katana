using Microsoft.Owin.Hosting;
using System;

namespace PoC.KatanaSelfHost
{
    public class HostService
    {
        private IDisposable WebApplication;

        public bool Start()
        {
            WebApplication = WebApp.Start<Startup>("http://localhost:5000");
            return true;
        }

        public bool Stop()
        {
            WebApplication.Dispose();
            return true;
        }
    }
}
