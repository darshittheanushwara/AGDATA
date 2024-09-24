using FluentValidation;
using TechnicalAssessment.Domain.Interfaces.Repositories;

namespace TechnicalAssessment.Domain.Commands.User.Validators
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            ValidateExists();
        }

        private void ValidateExists()
        {
            RuleFor(userBaseCommand => userBaseCommand.Id)
                .Must(id => _userRepository.Get(id) != null)
                .WithSeverity(Severity.Error)
                .WithMessage("User not exists.");
        }
    }
}
