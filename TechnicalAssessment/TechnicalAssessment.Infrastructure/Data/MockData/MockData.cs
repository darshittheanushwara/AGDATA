using TechnicalAssessment.Domain.Entities;

namespace TechnicalAssessment.Infrastructure.Data.MockData
{
    public class MockData
    {
        private readonly List<User> _data;
        private int _nextId;

        public MockData()
        {
            _data = new List<User>();
            _nextId = 1;

            // Adding some initial mock data
            _data.Add(new User { Id = Guid.NewGuid().ToString(), Name = "Darshit Shah", Address = "137 University ave w" });
            _data.Add(new User { Id = Guid.NewGuid().ToString(), Name = "Darshit Shah-1", Address = "137 University ave w" });
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _data;
        }

        public User GetUserById(string id)
        {
            return _data.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            _data.Add(user);
        }

        public void UpdateUser(User user)
        {
            var existingUser = GetUserById(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Address = user.Address;
            }
        }

        public void DeleteUser(string id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _data.Remove(user);
            }
        }
    }
}
