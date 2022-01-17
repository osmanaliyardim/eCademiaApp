using eCademiaApp.Core.Utilities.Interceptors;
using eCademiaApp.Core.Utilities.IoC;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace eCademiaApp.Core.Aspects.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private readonly int _interval;
        private readonly Stopwatch _stopwatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        // Starting timer before method is executed
        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        // If total time exceed default performance metrics returns controllerName.methodName -> secs passed
        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
                Debug.WriteLine(
                    $"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            _stopwatch.Reset(); // Resetting timer
        }
    }
}
