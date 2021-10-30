using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    // Autofac has Interceptor feature, default asp.net Ioc container doesn't.
    //Inherited: attribute also works for the classes that inherits this one.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
