using FluentValidation;
using TechnicalAssessment.Core.Commands;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Domain.Commands.User;
using TechnicalAssessment.Domain.Interfaces.Repositories;

namespace TechnicalAssessment.Application.User
{
    public class DeleteUserCommandHandler : CommandHandlerBase, ICommandHandler<DeleteUserCommand>
    {
        private readonly IValidator<DeleteUserCommand> _deleteUserCommandValidator;
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IValidator<DeleteUserCommand> deleteUserCommandValidator,
            IUserRepository userRepository)
        {
            _deleteUserCommandValidator = deleteUserCommandValidator;
            _userRepository = userRepository;
        }

        public Result Handle(DeleteUserCommand command)
        {
            var validationResult = Validate(command, _deleteUserCommandValidator);

            if (validationResult.IsValid)
            {
                _userRepository.Delete(command.Id);              
            }

            return Return();
        }
    }
}
