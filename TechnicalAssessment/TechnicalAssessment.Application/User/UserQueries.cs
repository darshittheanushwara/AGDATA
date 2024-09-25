using Raven.Client.Exceptions.Database;
using Raven.Client.Exceptions.Security;
using System.Net.Sockets;
using TechnicalAssessment.Domain.Interfaces.Repositories;
using TechnicalAssessment.Infrastructure.Data.MockData;


namespace TechnicalAssessment.Application.User
{
    public class UserQueries : IUserQueries
    {
        private readonly IUserRepository _userRepository;
        private readonly MockData _mockData;

        public UserQueries(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mockData = new MockData();
        }
        public Domain.Entities.User Get(string Id)
        {
            try
            {
                return _userRepository.Get(Id);
            }
            catch (Exception ex)
            {
                return _mockData.GetUserById(Id);
            }
        }

        public IEnumerable<Domain.Entities.User> GetAll()
        {
            try
            {
                return _userRepository.GetAll();
            }                    
            catch (Exception ex)
            {
                return _mockData.GetAllUsers();
            }
        }
    }
    public interface IUserQueries
    {
        IEnumerable<Domain.Entities.User> GetAll();
        Domain.Entities.User Get(string Id);
    }
}
