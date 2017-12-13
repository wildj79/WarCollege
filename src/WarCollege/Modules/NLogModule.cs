using Autofac;
using Autofac.Core;
using NLog;
using System.Linq;
using System.Reflection;

namespace WarCollege.Modules
{
    public class NLogModule : Autofac.Module
    {
        private static void InjectLoggerProperties(object instance)
        {
            var instanceType = instance.GetType();

            var properties = instanceType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(ILogger) && p.CanWrite && p.GetIndexParameters().Length == 0);

            foreach (var propToSet in properties)
            {
                propToSet.SetValue(instance, LogManager.GetLogger(instanceType.FullName), null);
            }
        }

        private static void OnComponentPreparing(object sender, PreparingEventArgs e)
        {
            e.Parameters = e.Parameters.Union(
                new[]
                {
                    new ResolvedParameter((p, i) => p.ParameterType == typeof(ILogger),
                        (p, i) => LogManager.GetLogger(p.Member.DeclaringType.FullName))
                }
            );
        }

        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            registration.Preparing += OnComponentPreparing;

            registration.Activated += (sender, e) => InjectLoggerProperties(e.Instance);
        }
    }
}
