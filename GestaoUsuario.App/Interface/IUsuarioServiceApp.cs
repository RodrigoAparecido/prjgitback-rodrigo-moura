using GestaoUsuario.App.RequestModel.Input.Usuario;
using GestaoUsuario.Domain.ParametroPesquisa;
using GestaoUsuario.Infra.Data;
using System.Threading.Tasks;

namespace GestaoUsuario.App.Interface
{
    public interface IUsuarioServiceApp
    {
        Task<object> Incluir(UsuarioPostRequest request);
    
        Task<Usuario> ConsultarUsuarios(UsuarioGetRequest usuarioGetRequest);

        Task<bool> ValidarSenha(UsuarioSenhaRequest request);


    }
}
