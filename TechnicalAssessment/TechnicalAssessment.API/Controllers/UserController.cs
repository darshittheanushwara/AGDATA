using Microsoft.AspNetCore.Mvc;
using TechnicalAssessment.Application.User;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Domain.Commands.User;

namespace TechnicalAssessment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICommandHandler<CreateUserCommand> _createUserCommandHandler;
        private readonly ICommandHandler<UpdateUserCommand> _updateUserCommandHandler;
        private readonly ICommandHandler<DeleteUserCommand> _deleteUserCommandHandler;
        private readonly IUserQueries _userQueries;

        public UserController(ICommandHandler<CreateUserCommand> createUserCommandHandler,
            ICommandHandler<UpdateUserCommand> updateUserCommandHandler,
            ICommandHandler<DeleteUserCommand> deleteUserCommandHandler,
            IUserQueries userQueries)
        {
            _createUserCommandHandler = createUserCommandHandler;
            _updateUserCommandHandler = updateUserCommandHandler;
            _deleteUserCommandHandler = deleteUserCommandHandler;
            _userQueries = userQueries;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userQueries.GetAll());
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult Get(string Id)
        {
            return Ok(_userQueries.Get(Id));
        }

        [HttpPost]
        public IActionResult Post(CreateUserCommand command)
        {
            var result = _createUserCommandHandler.Handle(command);

            if (result.Success)
                return Ok(command);

            return BadRequest(result.Errors);
        }

        [HttpPut]
        public IActionResult Put(UpdateUserCommand command)
        {
            var result = _updateUserCommandHandler.Handle(command);

            if (result.Success)
                return Ok(command);

            return BadRequest(result.Errors);
        }

        [HttpDelete]
        public IActionResult Delete(DeleteUserCommand command)
        {
            var result = _deleteUserCommandHandler.Handle(command);

            if (result.Success)
                return Ok(command);

            return BadRequest(result.Errors);
        }
    }
}
