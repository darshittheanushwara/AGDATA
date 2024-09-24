using FluentValidation;
using TechnicalAssessment.Application.AutoMapper;
using TechnicalAssessment.Core.Commands;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Domain.Commands.User;
using TechnicalAssessment.Domain.Commands.User.Validators;
using TechnicalAssessment.Domain.Interfaces.Repositories;

namespace TechnicalAssessment.Application.User
{
    public class UpdateUserCommandHandler : CommandHandlerBase, ICommandHandler<UpdateUserCommand>
    {
        private readonly IValidator<UpdateUserCommand> _updateeUserCommandValidaor;
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IValidator<UpdateUserCommand> userCommandValidaor,
            IUserRepository userRepository)
        {
            _updateeUserCommandValidaor = userCommandValidaor;
            _userRepository = userRepository;
        }

        public Result Handle(UpdateUserCommand command)
        {
            var validationResult = Validate(command, _updateeUserCommandValidaor);

            if (validationResult.IsValid)
            {
                var user = Mapper<Domain.Entities.User, UpdateUserCommand>.CommandToEntity(command);
                _userRepository.Update(user);
            }
            return Return();
        }
    }
}
