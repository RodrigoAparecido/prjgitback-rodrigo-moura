using AutoMapper;
using GestaoUsuario.App.Interface;
using GestaoUsuario.App.RequestModel.Input.Usuario;
using GestaoUsuario.App.Validators.Usuario;
using GestaoUsuario.Domain.Interface.Handler;
using GestaoUsuario.Domain.Interface.Service;
using GestaoUsuario.Domain.ParametroPesquisa;
using GestaoUsuario.Infra.Data;
using System;
using System.Threading.Tasks;

namespace GestaoUsuario.App.Service
{
    public class UsuarioServiceApp : IUsuarioServiceApp
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;
        private readonly IResponseErrorHandle _errorHandle;

        public UsuarioServiceApp(IMapper mapper, IUsuarioService usuarioService, IResponseErrorHandle errorHandle)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
            _errorHandle = errorHandle;
        }

        public async Task<object> Incluir(UsuarioPostRequest request)
        {
            var result = await new UsuarioSenhaValidator().ValidateAndThrowAsync(new UsuarioSenhaRequest { senha = request.PassWord});

            if (!result.IsValid)
            {
                _errorHandle.NewError(result);
                return _errorHandle;
            }

            var usuario = await _usuarioService.Incluir(_mapper.Map<Usuario>(request));

            if (!_usuarioService.responseErrorHandle.IsValid)
                return _usuarioService.responseErrorHandle;

            return usuario;
        }

        public async Task<Usuario> ConsultarUsuarios(UsuarioGetRequest usuarioGetRequest)
        {
            try
            {
                var usuarios = await _usuarioService.ConsultarUsuarios(usuarioGetRequest);

                if (!_usuarioService.responseErrorHandle.IsValid)
                    throw new Exception(_usuarioService.responseErrorHandle.Errors[0].ToString());

                return usuarios;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<bool> ValidarSenha(UsuarioSenhaRequest request)
        {

            var result = await new UsuarioSenhaValidator().ValidateAndThrowAsync(request);

            if (!result.IsValid)
            {
                return false;
            }
            
            return true;
        }
    }
}