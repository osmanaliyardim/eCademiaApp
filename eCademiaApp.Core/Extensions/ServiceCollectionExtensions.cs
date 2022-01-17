using eCademiaApp.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace eCademiaApp.Core.Extensions
{
    // Extends serviceCollection to automate dependency resolvers
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection,
            ICoreModule[] modules)
        {
            foreach (var module in modules) module.Load(serviceCollection);

            return ServiceTool.Create(serviceCollection);
        }
    }
}
