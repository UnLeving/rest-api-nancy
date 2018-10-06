using Persons.Interfaces;
using Persons.Models;
using Persons.Repositories;
using Serilog;

namespace Persons.Handlers
{
    public class PersonCommandHandler : ICommandHandler<Person>
    {
        public void Execute(Person command)
        {
            Log.Information(command.ToString());
            new PersonRepository().Insert(command);
        }
    }
}