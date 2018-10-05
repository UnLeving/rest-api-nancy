using Persons.Interfaces;
using Persons.Models;
using Persons.Repositories;

namespace Persons.Handlers
{
    public class PersonQueryHandler : IQueryHandler<int, Person>
    {
        public Person Execute(int query)
        {
            return new PersonRepository().Find(query);
        }
    }
}