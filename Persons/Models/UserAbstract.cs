using Persons.Interfaces;
using System;

namespace Persons.Models
{
    abstract public class UserAbstract : IAgeCalc
    {
        public int? id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public int? Age { get; protected set; }
        public abstract int? Calc();
    }
}