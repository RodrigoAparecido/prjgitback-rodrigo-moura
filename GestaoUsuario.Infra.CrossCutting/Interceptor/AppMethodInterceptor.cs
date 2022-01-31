using GestaoUsuario.Infra.CrossCutting.Handler;
using GestaoUsuario.Infra.CrossCutting.Registration;
using Castle.DynamicProxy;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace GestaoUsuario.Infra.CrossCutting.Interceptor
{
    public class AppMethodInterceptor : IInterceptor
    {
        private readonly IConfiguration _configuration = ComponentRegistration.For<IConfiguration>();

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

                invocation.ReturnValue = ErrorHandle(guid);
            }
        }
        private async Task<object> ErrorHandle(Guid guid)
        {
            var errorMessage =  _configuration["ErrorHandle:ErrorMessage"];

            var response = new ResponseErrorHandle();
            response.NewError($"{errorMessage} {guid}");

            return response;
        }
    }
}
