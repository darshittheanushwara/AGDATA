using TechnicalAssessment.Domain.Interfaces.Repositories;


namespace TechnicalAssessment.Application.User
{
    public class UserQueries : IUserQueries
    {
        private readonly IUserRepository _userRepository;

        public UserQueries(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Domain.Entities.User Get(string Id)
        {
            return _userRepository.Get(Id);
        }

        public IEnumerable<Domain.Entities.User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
    public interface IUserQueries
    {
        IEnumerable<Domain.Entities.User> GetAll();
        Domain.Entities.User Get(string Id);
    }
}
