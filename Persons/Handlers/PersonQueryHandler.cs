using Persons.Interfaces;
using Persons.Models;
using Persons.Repositories;
using System;

namespace Persons.Handlers
{
    public class PersonQueryHandler : IQueryHandler<Guid, Person>
    {
        public Person Execute(Guid query)
        {
            return new PersonRepository().Find(query);
        }
    }
}