namespace ChatApp.Framework.Input;

using FluentValidation.Results;

public interface IValidationMediator
{
    ValidationResult Validate<T>(T model);
}