using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Entity;

namespace TechnicalAssessment.Core.Interfaces
{
    public interface IRepository<T> : IDisposable where T : IEntity
    {
        // Adds a new entity to the repository
        void Add(T entity);

        // Updates an existing entity in the repository
        void Update(T entity);

        // Deletes an entity from the repository based on its ID
        void Delete(string id);

        // Retrieves an entity from the repository based on its ID
        T Get(string id);

        // Retrieves all entities from the repository
        IEnumerable<T> GetAll();

    }
}
