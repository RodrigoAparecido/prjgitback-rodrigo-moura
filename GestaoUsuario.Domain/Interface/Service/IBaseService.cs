using GestaoUsuario.Domain.Interface.Handler;

namespace GestaoUsuario.Domain.Interface.Service
{
    public interface IBaseService
    {
        IResponseErrorHandle responseErrorHandle { get; }
    }
}
