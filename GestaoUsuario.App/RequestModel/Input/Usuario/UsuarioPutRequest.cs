
namespace GestaoUsuario.App.RequestModel.Input.Usuario
{
    public class UsuarioPutRequest : Request
    {
        public long ID { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public string CPF { get; set; }

    }
}

