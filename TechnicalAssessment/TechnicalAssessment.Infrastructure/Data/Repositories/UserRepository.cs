using TechnicalAssessment.Domain.Entities;
using TechnicalAssessment.Domain.Interfaces.Repositories;
using TechnicalAssessment.Infrastructure.Data.Context;

namespace TechnicalAssessment.Infrastructure.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext)
             : base(dbContext)
        {
                
        }
    }
}
