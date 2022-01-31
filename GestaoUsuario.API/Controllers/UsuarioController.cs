using GestaoUsuario.App.Interface;
using GestaoUsuario.App.Model;
using GestaoUsuario.App.RequestModel.Input.Usuario;
using GestaoUsuario.Infra.CrossCutting.Handler;
using GestaoUsuario.Infra.CrossCutting.Registration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace GestaoUsuario.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : Base
    {
        IUsuarioServiceApp _usuarioServiceApp;


        [HttpPost]
        [Route("ValidarSenha")]
        [ProducesResponseType(typeof(UsuarioSenhaModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseErrorHandle), (int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> ValidarSenha([FromBody] UsuarioSenhaRequest request)
        {
            _usuarioServiceApp = ComponentRegistration.For<IUsuarioServiceApp>();

            var response = await _usuarioServiceApp.ValidarSenha(request);

            return RetornoPadrao(new UsuarioSenhaModel { SenhaValida = response});
        }

        [HttpPost]
        [Route("CriaSenha")]
        [ProducesResponseType(typeof(ResultModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseErrorHandle), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Incluir([FromBody] UsuarioPostRequest request)
        {
            _usuarioServiceApp = ComponentRegistration.For<IUsuarioServiceApp>();

            var response = await _usuarioServiceApp.Incluir(request);
            return RetornoPadrao(new ResultModel { result = "Senha válida criada" });
        }


    }
}