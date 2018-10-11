using System;

namespace Persons.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity Find(Guid id);
        void Insert(TEntity item);
    }
}