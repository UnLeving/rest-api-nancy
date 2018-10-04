namespace Persons.Interfaces
{
    public interface IRepository<T>
    {
        T Find(int id);
        void Insert(T item);
    }
}
