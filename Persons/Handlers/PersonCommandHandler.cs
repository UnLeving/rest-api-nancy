using Persons.Interfaces;
using Persons.Models;
using Persons.Repositories;

namespace Persons.Handlers
{
    public class PersonCommandHandler : ICommandHandler<Person>
    {
        public void Execute(Person command)
        {
            new PersonRepository().Insert(command);
        }
    }
}