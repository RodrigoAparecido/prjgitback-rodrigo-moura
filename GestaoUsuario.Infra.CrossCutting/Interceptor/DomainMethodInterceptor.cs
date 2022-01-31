using Castle.DynamicProxy;
using System;
using System.Threading.Tasks;

namespace GestaoUsuario.Infra.CrossCutting.Interceptor
{
    public class DomainMethodInterceptor : IInterceptor
    {

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();

                if (invocation.Method.ReturnType.BaseType == typeof(Task))
                    ((Task)invocation.ReturnValue).Wait();
                
            }
            catch
            {
                var guid = Guid.NewGuid();

            }
        }
    }
}
