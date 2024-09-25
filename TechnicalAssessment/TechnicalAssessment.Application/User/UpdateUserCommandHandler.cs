using FluentValidation;
using TechnicalAssessment.Application.AutoMapper;
using TechnicalAssessment.Core.Commands;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Domain.Commands.User;
using TechnicalAssessment.Domain.Commands.User.Validators;
using TechnicalAssessment.Domain.Interfaces.Repositories;
using TechnicalAssessment.Infrastructure.Data.MockData;

namespace TechnicalAssessment.Application.User
{
    public class UpdateUserCommandHandler : CommandHandlerBase, ICommandHandler<UpdateUserCommand>
    {
        private readonly IValidator<UpdateUserCommand> _updateeUserCommandValidaor;
        private readonly IUserRepository _userRepository;
        private readonly MockData _mockData;

        public UpdateUserCommandHandler(IValidator<UpdateUserCommand> userCommandValidaor,
            IUserRepository userRepository)
        {
            _updateeUserCommandValidaor = userCommandValidaor;
            _userRepository = userRepository;
            _mockData = new MockData();
        }

        public Result Handle(UpdateUserCommand command)
        {
            var validationResult = Validate(command, _updateeUserCommandValidaor);

            if (validationResult.IsValid)
            {
                var user = Mapper<Domain.Entities.User, UpdateUserCommand>.CommandToEntity(command);
                try
                {
                    _userRepository.Update(user);
                }
                catch (Exception ex)
                {
                    _mockData.UpdateUser(user);
                }
            }
            return Return();
        }
    }
}
