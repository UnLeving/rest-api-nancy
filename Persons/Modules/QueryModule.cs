using AutoMapper;
using Nancy;
using Persons.Interfaces;
using Persons.Models;

namespace Persons.Modules
{
    public class QueryModule : NancyModule
    {
        public QueryModule(IQueryHandler<int, Person> queryHandler)
        {
            Get["/api/v1/persons/{id:int}"] = parameters =>
            {
                Person person = queryHandler.Execute(parameters.id);
                return person == null ? HttpStatusCode.NotFound : Response.AsJson(Mapper.Map<PersonDto>(person));
            };

        }
    }
}