using Microsoft.AspNetCore.Cors;
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
            var userList= _userQueries.GetAll();

            if (userList.Count() == 0)
            {
                
            }

            return Ok(userList);
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
        [Route("{Id}")]
        public IActionResult Delete(string Id)
        {
            var command = new DeleteUserCommand { Id = Id };            
            var result = _deleteUserCommandHandler.Handle(command);

            if (result.Success)
                return Ok(command);

            return BadRequest(result.Errors);
        }
    }
}
