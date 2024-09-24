using TechnicalAssessment.Core.Commands;

namespace TechnicalAssessment.Core.Interfaces
{
    public interface ICommandHandler<in T> where T : CommandBase
    {
        Result Handle(T command);
    }
}
