using Castle.DynamicProxy;
using eCademiaApp.Core.CrossCuttingConcerns.Caching;
using eCademiaApp.Core.Utilities.Interceptors;
using eCademiaApp.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace eCademiaApp.Core.Aspects.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private readonly ICacheManager _cacheManager;
        private readonly string _pattern;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
