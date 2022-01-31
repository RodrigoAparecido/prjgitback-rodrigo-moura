using GestaoUsuario.Domain.Model;
using GestaoUsuario.Domain.ParametroPesquisa;
using GestaoUsuario.Infra.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoUsuario.Domain.Interface.Service
{
    public interface IUsuarioService : IBaseService
    {
        Task<Usuario> Incluir(Usuario usuario);

        Task<Usuario> ConsultarUsuarios(UsuarioGetRequest usuarioGetRequest);

    }
}
