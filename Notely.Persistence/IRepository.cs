using System.Collections.Generic;

namespace Notely.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        TEntity Update(TEntity entity);

        int Commit();
    }
}

