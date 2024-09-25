using FluentValidation;
using TechnicalAssessment.Application.AutoMapper;
using TechnicalAssessment.Core.Commands;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Domain.Commands.User;
using TechnicalAssessment.Domain.Interfaces.Repositories;
using TechnicalAssessment.Infrastructure.Data.MockData;

namespace TechnicalAssessment.Application.User
{
    public class CreateUserCommandHandler : CommandHandlerBase, ICommandHandler<CreateUserCommand>
    {
        private readonly IValidator<CreateUserCommand> _createUserCommandValidaor;
        private readonly IUserRepository _userRepository;
        private readonly MockData _mockData;

        public CreateUserCommandHandler(IValidator<CreateUserCommand> userCommandValidaor,
            IUserRepository userRepository)
        {
            _createUserCommandValidaor = userCommandValidaor;
            _userRepository = userRepository;
            _mockData = new MockData();
        }
        public Result Handle(CreateUserCommand command)
        {
            var validationResult = Validate(command, _createUserCommandValidaor);

            if (validationResult.IsValid)
            {
                var user = Mapper<Domain.Entities.User, CreateUserCommand>.CommandToEntity(command);
                try
                {
                    _userRepository.Add(user);
                }
                catch (Exception ex)
                {
                    _mockData.AddUser(user);
                }
            }
            return Return();
        }
    }
}
