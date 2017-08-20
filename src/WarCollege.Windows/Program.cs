using System;
using Autofac;

namespace WarCollege.Windows
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var bootstrapper = new IocBootstraper();
            var container = bootstrapper.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<Eto.Forms.Application>();
                app.Run();
            }
        }
    }
}
