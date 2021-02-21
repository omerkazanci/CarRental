using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    // Bu attribute                 Class ve Metodlar için          birden fazla yerde  ve  inherit edilen yerde de çalışacak 
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }

}
