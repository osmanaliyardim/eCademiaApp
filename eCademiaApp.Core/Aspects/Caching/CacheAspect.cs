using Castle.DynamicProxy;
using eCademiaApp.Core.CrossCuttingConcerns.Caching;
using eCademiaApp.Core.Utilities.Interceptors;
using eCademiaApp.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace eCademiaApp.Core.Aspects.Caching
{
    // To cache and check is cached method or not before method is executed
    public class CacheAspect : MethodInterception
    {
        // Injectable services
        private readonly ICacheManager _cacheManager;
        private readonly int _duration;

        // Injecting our services to establish a loosely coupled connection
        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}"); // For example: Courses.getAll
            var arguments = invocation.Arguments.ToList(); // Parameters if it exists
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; // Courses.getById(id) or Courses.GetAll()
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key); // Adding methods we want to cache
                return;
            }

            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration); // Caching them for a duration
        }
    }
}
