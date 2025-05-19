using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Hat.Application.Registeration
{
    public static class ApplicationServiceRegisteration
    {
        public static IServiceCollection AddHatApplications(this IServiceCollection services, params string[] assemblyNames)
        {
            var assemblies = new List<Assembly> { Assembly.GetExecutingAssembly() };

            foreach (var assemblyName in assemblyNames)
            {
                assemblies.Add(Assembly.Load(assemblyName));
            }

            if (!assemblies.Any())
            {
                throw new InvalidOperationException("No valid assemblies found for MediatR registration.");
            }
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies.ToArray()));
            return services;
        }

    }
}
