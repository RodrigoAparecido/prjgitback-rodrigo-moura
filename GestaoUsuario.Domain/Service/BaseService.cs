using System;
using System.Reflection;
using GestaoUsuario.Domain.Interface.Handler;

namespace GestaoUsuario.Domain.Service
{
    public class BaseService
    {
        public IResponseErrorHandle responseErrorHandle { get; }
        public BaseService(IResponseErrorHandle errorHandle)
        {
            responseErrorHandle = errorHandle;
        }

        public static object CloneObject(object objOrigem, object objDestino)
        {
            if (objOrigem != null && objDestino != null && objOrigem.GetType().Equals(objDestino.GetType()))
            {
                Type pTipo = objOrigem.GetType();
                PropertyInfo[] pNome = pTipo.GetProperties();

                foreach (PropertyInfo propriedade in pNome)
                {
                    if (propriedade.Name == "DataInclusao")
                        continue;

                    propriedade.SetValue(objDestino, propriedade.GetValue(objOrigem, null), null);
                }
                    
            }
            else
                objDestino = null;

            return objDestino;
        }
    }
}
