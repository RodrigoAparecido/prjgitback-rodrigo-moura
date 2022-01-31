using FluentValidation.Results;
using System.Collections.Generic;
using GestaoUsuario.Domain.Interface.Handler;
using GestaoUsuario.Infra.CrossCutting.Model;

namespace GestaoUsuario.Infra.CrossCutting.Handler
{
    public class ResponseErrorHandle : IResponseErrorHandle
    {
        public bool IsValid { get; private set; } = true;
        public List<object> Errors { get; private set; }

        public ResponseErrorHandle()
        {
        }

        public ResponseErrorHandle(string errorMessage)
        {
            NewError(errorMessage);
        }

        public object NewError(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                NewError(($"{error.PropertyName}: {error.ErrorMessage}"));
            }
            IsValid = false;
            return null;
        }

        public object NewError(string errorMessage)
        {
            if (Errors is null)
            {
                Errors = new List<object>();
                IsValid = false;
            }

            Errors.Add(new Error(errorMessage));
            return null;
        }

        public object NewError(List<object> errors)
        {
            Errors = errors;
            IsValid = false;
            return null;
        }
    }
}

