using System;

namespace Persons.Models
{
    public class Person : Factory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return DateTime.Now + " Name: " + Name + " BirthDay:" + BirthDay;
        }
        public  Person Create(string name, DateTime bd)
        {
            int age = DateTime.Now.Year - bd.Year;
            if (name == string.Empty || age > 120) return null;
            return new Person()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Age = age,
                BirthDay = bd
            };
        }
    }
}