using Persons.Interfaces;
using System;

namespace Persons.Models
{
    abstract public class UserAbstract : IAgeCalc
    {
        public string Name { get; set; }
        public virtual DateTime BirthDay { get; set; }
        public int? Age { get; protected set; }
        public abstract int? Calc();
    }
}