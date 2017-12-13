using System;
using Autofac;

namespace WarCollege.Windows
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var container = IocBootstraper.InitializeContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                //var app = scope.Resolve<Eto.Forms.Application>();
                //app.Run();
            }
        }
    }
}
