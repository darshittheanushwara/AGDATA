using Raven.Client.Documents;
using TechnicalAssessment.Core.Entity;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Infrastructure.Data.Context;

namespace TechnicalAssessment.Infrastructure.Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : IEntity
    {
        private readonly IDocumentStore _documentStore;

        public RepositoryBase(DbContext context)
        {
            _documentStore = context.GetStore();
        }

        // Adds a new entity to the repository
        public void Add(T entity)
        {
            using (var session = _documentStore.OpenSession())
            {
                session.Store(entity);
                session.SaveChanges();
            }
        }

        // Updates an existing entity in the repository
        public void Update(T entity)
        {
            using (var session = _documentStore.OpenSession())
            {
                session.Store(entity);
                session.SaveChanges();
            }
        }

        // Deletes an entity from the repository based on its ID
        public void Delete(string id)
        {
            using (var session = _documentStore.OpenSession())
            {
                var entity = session.Load<T>(id);
                if (entity != null)
                {
                    session.Delete(entity);
                    session.SaveChanges();
                }
            }
        }

        // Retrieves an entity from the repository based on its ID
        public T Get(string id)
        {
            using (var session = _documentStore.OpenSession())
            {
                return session.Load<T>(id);
            }
        }

        // Retrieves all entities from the repository
        public IEnumerable<T> GetAll()
        {
            using (var session = _documentStore.OpenSession())
            {
                return session.Query<T>().ToList();
            }
        }      

        public void Dispose()
        {            
            GC.SuppressFinalize(this);
        }
    }
}
