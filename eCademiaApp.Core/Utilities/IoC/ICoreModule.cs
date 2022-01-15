using Microsoft.Extensions.DependencyInjection;

namespace eCademiaApp.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
