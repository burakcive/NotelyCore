using System.Collections.Generic;

namespace Notely.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
    }
}

