using FluentValidation;

namespace TechnicalAssessment.Domain.Commands.User.Validators
{
    public abstract class UserCommandValidatorBase<T> : AbstractValidator<T> where T : UserCommandBase
    {
        protected UserCommandValidatorBase()
        {
                  
            ValidateName();           
        }

        private void ValidateName()
        {
            RuleFor(userBaseCommand => userBaseCommand.Name)
                .Must(title => !string.IsNullOrWhiteSpace(title))
                .WithSeverity(Severity.Error)
                .WithMessage("Name can't be empty");
        }
    }
}
