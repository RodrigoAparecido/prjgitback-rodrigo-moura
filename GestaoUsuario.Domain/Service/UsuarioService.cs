
using GestaoUsuario.Domain.Enums;
using GestaoUsuario.Domain.Interface.Handler;
using GestaoUsuario.Domain.Interface.Repository;
using GestaoUsuario.Domain.Interface.Service;
using GestaoUsuario.Domain.ParametroPesquisa;
using GestaoUsuario.Infra.Data;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoUsuario.Domain.Service
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioReadOnlyRepository _usuarioReadOnlyRepository;
        private readonly IConfiguration _configuration;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IUsuarioReadOnlyRepository usuarioReadOnlyRepository,
            IConfiguration configuration,
            IResponseErrorHandle errorHandle) : base(errorHandle)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioReadOnlyRepository = usuarioReadOnlyRepository;
            _configuration = configuration;
        }

        public async Task<Usuario> Incluir(Usuario usuario)
        {
            var getUser = await _usuarioRepository.ConsultarPorLogin(usuario.Login);
            if (getUser != null)
            {
                responseErrorHandle.NewError(string.Format(EMensagemErro.UsuarioJaCadastado.GetDisplayName(), usuario.Login));
                return await Task.FromResult<Usuario>(null);
            }
            await _usuarioRepository.Incluir(usuario);

            return usuario;
        }

        public async Task<Usuario> ConsultarUsuarios(UsuarioGetRequest usuarioGetRequest)
        {
            IQueryable<Usuario> query = _usuarioReadOnlyRepository.ConsultarPelaExpressao(x =>
                  (usuarioGetRequest.Login != null ? x.Login.ToLower().Contains(usuarioGetRequest.Login.ToLower()) : true) &&
                  (usuarioGetRequest.PassWord != null ? x.PassWord.Contains(usuarioGetRequest.PassWord) : true)
              );
          
            var usuarios = await _usuarioReadOnlyRepository.ConsultarUsuarios(query);
         
            return usuarios;
        }
    }
}
