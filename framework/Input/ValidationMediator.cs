namespace ChatApp.Framework.Input;

using FluentValidation.Results;
using ChatApp.Framework.Registries;

public class ValidationMediator : IValidationMediator
{
    public ValidationResult Validate<T>(T model)
    {
        ValidatorRegistry validatorRegistry =  new ValidatorRegistry();
        var validator = validatorRegistry.GetValidator<T>();
        return validator.Validate(model);
    }
}