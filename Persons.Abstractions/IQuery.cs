namespace Persons.Abstractions
{
    public interface IQuery<in TQuery>
    {
        dynamic GetPerson(TQuery id);
    }
}