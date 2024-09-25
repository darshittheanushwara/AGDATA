using FluentValidation;
using TechnicalAssessment.Core.Commands;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Domain.Commands.User;
using TechnicalAssessment.Domain.Interfaces.Repositories;
using TechnicalAssessment.Infrastructure.Data.MockData;

namespace TechnicalAssessment.Application.User
{
    public class DeleteUserCommandHandler : CommandHandlerBase, ICommandHandler<DeleteUserCommand>
    {
        private readonly IValidator<DeleteUserCommand> _deleteUserCommandValidator;
        private readonly IUserRepository _userRepository;
        private readonly MockData _mockData;

        public DeleteUserCommandHandler(IValidator<DeleteUserCommand> deleteUserCommandValidator,
            IUserRepository userRepository)
        {
            _deleteUserCommandValidator = deleteUserCommandValidator;
            _userRepository = userRepository;
            _mockData = new MockData();
        }

        public Result Handle(DeleteUserCommand command)
        {
            var validationResult = Validate(command, _deleteUserCommandValidator);

            if (validationResult.IsValid)
            {
                try
                {
                    _userRepository.Delete(command.Id);
                }
                catch (Exception ex)
                {
                    _mockData.DeleteUser(command.Id);
                }
            }
            return Return();
        }
    }
}
