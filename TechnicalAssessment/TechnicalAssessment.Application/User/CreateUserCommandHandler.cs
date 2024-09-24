using FluentValidation;
using TechnicalAssessment.Application.AutoMapper;
using TechnicalAssessment.Core.Commands;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Domain.Commands.User;
using TechnicalAssessment.Domain.Interfaces.Repositories;

namespace TechnicalAssessment.Application.User
{
    public class CreateUserCommandHandler : CommandHandlerBase, ICommandHandler<CreateUserCommand>
    {
        private readonly IValidator<CreateUserCommand> _createUserCommandValidaor;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IValidator<CreateUserCommand> userCommandValidaor,
            IUserRepository userRepository)
        {
            _createUserCommandValidaor = userCommandValidaor;
            _userRepository = userRepository;
        }
        public Result Handle(CreateUserCommand command)
        {
            var validationResult = Validate(command, _createUserCommandValidaor);

            if (validationResult.IsValid)
            {
                var user = Mapper<Domain.Entities.User, CreateUserCommand>.CommandToEntity(command); ;
                _userRepository.Add(user);              
            }
            return Return();
        }
    }
}
