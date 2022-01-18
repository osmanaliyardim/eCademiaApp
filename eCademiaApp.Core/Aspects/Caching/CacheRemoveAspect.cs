using Castle.DynamicProxy;
using eCademiaApp.Core.CrossCuttingConcerns.Caching;
using eCademiaApp.Core.Utilities.Interceptors;
using eCademiaApp.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace eCademiaApp.Core.Aspects.Caching
{
    // To remove cache when a new course (product) added or existing one is deleted or updated
    public class CacheRemoveAspect : MethodInterception
    {
        private readonly ICacheManager _cacheManager;
        private readonly string _pattern;

        // To reach -> Courses.GetById(id)
        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern); // To apply when add, delete or update successfully completed
        }
    }
}
