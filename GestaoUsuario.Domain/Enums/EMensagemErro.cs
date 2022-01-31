using System.ComponentModel.DataAnnotations;

namespace GestaoUsuario.Domain.Enums
{
    public enum EMensagemErro
    {
        [Display(Name = "Login já cadastrado {0}")]
        UsuarioJaCadastado = 1,

        [Display(Name = "ClienteID Não Informado")]
        ClienteIDNaoInformado = 2,

        [Display(Name = "Usuário não cadastrado")]
        UsuarioNaoCadastrado = 3,

        [Display(Name = "Login Cadastrado Para Outro Usuário")]
        LoginCadastradoParaOutroUsuario = 4,

        [Display(Name = "Cliente não encontrado")]
        ClienteNaoEncontrado = 5,

        [Display(Name = "Os Perfis informados não são válidos")]
        PerfisInvalidos = 6,

        [Display(Name = "Documento do ClienteMotorsis não Informado")]
        DocumentoClienteMotorsisNaoInformado = 7,

        [Display(Name = "Documento do ClienteMotorsis inválido")]
        DocumentoClienteMotorsisInvalido = 8
    }
}
