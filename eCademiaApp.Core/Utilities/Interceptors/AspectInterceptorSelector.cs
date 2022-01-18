using Castle.DynamicProxy;
using eCademiaApp.Core.Aspects.Performance;
using System.Reflection;

namespace eCademiaApp.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        /// <summary>This method selects interceptor(s).</summary>
        /// <param name="type">class you want to apply AOP</param>
        /// <param name="method">method you want to invoke</param>
        /// <param name="interceptors">interceptors when you want to apply your metrics</param>
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
