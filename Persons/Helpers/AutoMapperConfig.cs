using AutoMapper;
using Persons.Models;

namespace Persons.Helpers
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(config => config.CreateMap<Person, PersonDto>());
        }
    }
}