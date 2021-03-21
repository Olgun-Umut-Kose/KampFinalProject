using System.Diagnostics;
using Castle.DynamicProxy;
using Core.Utilities.Interception;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.AutoFac.Performance
{
    public class PerformansAspect : MethodInterception
    {
        private float _interval;
        private Stopwatch _stopwatch;

        public PerformansAspect(float interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.Write(invocation.Method.ReflectedType.FullName+"." + invocation.Method.Name + " istenilen süreden uzun sürdü tamamlanma süresi -->" + _stopwatch.Elapsed.TotalSeconds);
                
            }
            _stopwatch.Stop();
            _stopwatch.Reset();
        }
    }
}