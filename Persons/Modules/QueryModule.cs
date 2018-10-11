using AutoMapper;
using Nancy;
using Persons.Interfaces;
using Persons.Models;
using System;

namespace Persons.Modules
{
    public class QueryModule : NancyModule
    {
        public QueryModule(IQueryHandler<Guid, Person> queryHandler)
        {
            //for test guid e36c166a-4497-4be2-8a52-0faa15912f1d
            Get["/api/v1/persons/{id}"] = parameters =>
            {
                Person person = queryHandler.Execute(parameters.id);
                return person == null ? HttpStatusCode.NotFound : Response.AsJson(Mapper.Map<PersonDto>(person));
            };

        }
    }
}