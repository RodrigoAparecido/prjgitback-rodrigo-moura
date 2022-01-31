
using GestaoUsuario.Infra.CrossCutting.Handler;
using Microsoft.AspNetCore.Mvc;

namespace GestaoUsuario.API.Controllers
{
    public class Base : ControllerBase
    {
        protected IActionResult RetornoPadrao(object response)
        {
            if (response.GetType() == (typeof(ResponseErrorHandle)))
                return BadRequest(response);

            return Ok(response);
        }
    }
}
