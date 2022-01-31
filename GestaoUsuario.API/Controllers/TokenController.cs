using GestaoUsuario.App.Interface;
using GestaoUsuario.App.Model;
using GestaoUsuario.App.RequestModel.Input.Token;
using GestaoUsuario.Infra.CrossCutting.Handler;
using GestaoUsuario.Infra.CrossCutting.Registration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestaoUsuario.API.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Base
    {
      
       IUsuarioServiceApp _usuarioServiceApp ;


        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(TokenModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseErrorHandle), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorHandle), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Token(TokenRequest user)
        {
            try
            {
                _usuarioServiceApp = ComponentRegistration.For<IUsuarioServiceApp>();

                var objUser = await this._usuarioServiceApp.ConsultarUsuarios(new Domain.ParametroPesquisa.UsuarioGetRequest {
                    Login = user.Login,
                    PassWord = user.Senha
                });

                if (objUser != null)
                {
           
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                  
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e")), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    var result = new TokenModel { autenticado = "True", usuario = objUser.Login , token_access = tokenHandler.WriteToken(token), token_type = "bearer" , expires_in = token.ValidTo};

                    return Ok(result);
             
                }
                else
                    return Unauthorized(new ResponseErrorHandle("Usuário não encontrado."));
            }
            catch
            {
                return RetornoPadrao(new ResponseErrorHandle("Ocorreu um problema de comunicação com o serviço de autenticação. Tente novamente."));
            }
        }

    }
}
