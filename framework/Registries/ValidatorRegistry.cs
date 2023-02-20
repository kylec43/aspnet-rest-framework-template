namespace ChatApp.Framework.Registries;

using ChatApp.Framework.Util;
using FluentValidation;

public class ValidatorRegistry
{
    private readonly Dictionary<Type, object?> _validators = new Dictionary<Type, object?>();

    /*
     Example of validator class:
     public class ProfileValidator : AbstractValidator<Profile> {}
    */
    public ValidatorRegistry()
    {
        var validatorTypes = ReflectionTool.GetTypesFromNameSpace(@"ChatApp[.].*Inputs");

        // Iterate over validator type -> e.g. ProfileValidator
        foreach (var validatorType in validatorTypes)
        {
            if (!validatorType.ToString().EndsWith("Validator"))
            {
                continue;
            }

            // Get the validator interface IValidator<> -> AbstractValidator implements this
            var validatorInterfaceType = validatorType
                .GetInterfaces()
                .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IValidator<>));

            // If that interface exists in the class, get the class from the template -> e.g. Profile
            if (validatorInterfaceType != null)
            {
                var validatedType = validatorInterfaceType.GetGenericArguments()[0];
                var validatorInstance = Activator.CreateInstance(validatorType);
                _validators[validatedType] = validatorInstance;
            }
        }
    }

    public IValidator<T>? GetValidator<T>()
    {
        if (_validators.TryGetValue(typeof(T), out var validator))
        {
            return (IValidator<T>?)validator;
        }

        return null;
    }
}