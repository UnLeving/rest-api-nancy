namespace Persons.Abstractions
{
    public interface IQueryHandler
    {
        dynamic GetPerson(int id);
    }
}
