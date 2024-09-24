using TechnicalAssessment.Core.Commands;

namespace TechnicalAssessment.Domain.Commands.User
{
    public abstract class UserCommandBase : CommandBase
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
