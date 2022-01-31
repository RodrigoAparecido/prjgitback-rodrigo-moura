using FluentValidation.Results;
using System.Collections.Generic;

namespace GestaoUsuario.Domain.Interface.Handler
{
    public interface IResponseErrorHandle
    {
        bool IsValid { get; }
        List<object> Errors { get; }
        object NewError(ValidationResult validationResult);
        object NewError(List<object> errors);

        object NewError(string errorMessage);
    }
}
