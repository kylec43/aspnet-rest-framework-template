namespace ChatApp.Profile.Inputs;

using FluentValidation;

public class ProfileIdValidator : AbstractValidator<ProfileIdInput>
{
    public ProfileIdValidator()
    {
        RuleFor(input => input.id).Custom(validateId).NotEmpty().WithMessage("Id Required");
    }

    public void validateId(int id, ValidationContext<ProfileIdInput> context)
    {
        if (id < 0) {
            context.AddFailure("Invalid profile id");
        }
    }
}