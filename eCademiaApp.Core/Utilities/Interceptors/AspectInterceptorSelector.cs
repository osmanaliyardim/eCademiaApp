using Castle.DynamicProxy;
using eCademiaApp.Core.Aspects.Performance;
using System.Reflection;

namespace eCademiaApp.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new PerformanceAspect(5)); //TODO : performance unavailable

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
