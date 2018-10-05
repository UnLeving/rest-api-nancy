using Persons.Abstractions;
using System;

namespace Persons.Models
{
    public class Person : UserAbstract, ICommand
    {
        public override int? Calc()
        {
            Age = DateTime.Now.Year - BirthDay.Year;
            return Age > 120 || Name == string.Empty ? null : Age;
        }

        public dynamic CreatePerson()
        {
            throw new NotImplementedException();
        }
    }
}