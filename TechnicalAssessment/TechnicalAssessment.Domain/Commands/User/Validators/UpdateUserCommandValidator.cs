using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Domain.Commands.User.Validators
{
    public class UpdateUserCommandValidator : UserCommandValidatorBase<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            ValidateId();
        }
        private void ValidateId()
        {
            RuleFor(updateUserCommand => updateUserCommand.Id)
                .Must(id => !id.Equals(Guid.Empty))
                .WithSeverity(Severity.Error)
                .WithMessage("Id can't be empty");
        }
    }
}
