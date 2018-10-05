namespace Persons.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity Find(int id);
        void Insert(TEntity item);
    }
}