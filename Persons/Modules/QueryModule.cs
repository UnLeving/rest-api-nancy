using AutoMapper;
using Nancy;
using Persons.Abstractions;
using Persons.Interfaces;
using Persons.Models;
using Persons.Repositories;

namespace Persons.Modules
{
    public class QueryModule : NancyModule, IQueryHandler
    {
        IPersonRepository repository = new PersonRepository();
        public QueryModule()
        {
            Get["/api/v1/persons/{id}"] = parameters => GetPerson(parameters.id);
        }
        public dynamic GetPerson(int id)
        {
            var person = repository.Find(id);
            return person == null ? HttpStatusCode.NotFound : Response.AsJson(Mapper.Map<PersonDto>(person));
        }
    }
}