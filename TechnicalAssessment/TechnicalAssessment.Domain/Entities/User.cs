using TechnicalAssessment.Core.Entity;

namespace TechnicalAssessment.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }

        public string Address { get; private set; }

        public User(string name, string address)
        {
            Name = name;
            Address = address;
        }

        protected User()
        {
        }
    }
}
