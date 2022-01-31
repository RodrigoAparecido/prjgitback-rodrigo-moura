using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace GestaoUsuario.App.Validators
{
    public class BaseValidator<T> : AbstractValidator<T>
    {
        public async Task<ValidationResult> ValidateAndThrowAsync(T schema)
        {
            ValidationResult results = await ValidateAsync(schema);
            return results;
        }
    }
}