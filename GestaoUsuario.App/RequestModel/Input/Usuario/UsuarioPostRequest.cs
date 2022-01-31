
namespace GestaoUsuario.App.RequestModel.Input.Usuario
{
    public class UsuarioPostRequest : Request
    {
        public string Login { get; set; }

        public string PassWord { get; set; }


    }

    public class ValidaSenhaRequest
    {
        public string senha { get; set; }


    }
}
