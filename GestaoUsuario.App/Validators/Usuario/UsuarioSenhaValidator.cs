using GestaoUsuario.App.RequestModel.Input.Usuario;
using FluentValidation;
using System.Text.RegularExpressions;
using System.Linq;

namespace GestaoUsuario.App.Validators.Usuario
{
    public class UsuarioSenhaValidator : BaseValidator<UsuarioSenhaRequest>
    {
        public UsuarioSenhaValidator()
        {
            RuleFor(x => x.senha)
                .NotEmpty().WithMessage("Informe a senha")
                .Length(15, 50).WithMessage("Senha deve ter no mínimo 15 e no máximo 50 caractéres")
                .Must(RequireDigit).WithMessage("Senha deve ter pelo menos 1 número")
                .Must(RequiredLowerCase).WithMessage("Senha deve ter pelo menos 1 caracter minúsculo")
                .Must(RequireUppercase).WithMessage("Senha deve ter pelo menos 1 caracter maiúsculo")
                .Must(RequireNonAlphanumeric).WithMessage("Digite pelo menos 1 caracter especial (@ ! & * ...)")
                .Must(NoRequireCharactersepeated).WithMessage("Não poder ter caracteres repetidos em sequência"); 

        }

        private bool RequireDigit(string password)
        {
            if (password.Any(x => char.IsDigit(x)))
            {
                return true;
            }
            return false;
        }

        private bool RequiredLowerCase(string password)
        {
            if (password.Any(x => char.IsLower(x)))
            {
                return true;
            }
            return false;
        }

        private bool RequireUppercase(string password)
        {
            if (password.Any(x => char.IsUpper(x)))
            {
                return true;
            }
            return false;
        }

        private bool RequireNonAlphanumeric(string password)
        {            
            if (Regex.IsMatch(password, "(?=.*[@#_!-])"))
            {
                return true;
            }
            return false;
        }

        private bool NoRequireCharactersepeated(string password)
        {

            if (Regex.IsMatch(password, @"(.)\1{3}"))
            {
                return false;
            }
            return true;
        }
    }
}
