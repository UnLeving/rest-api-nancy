using System;

namespace Persons.Models
{
    public class Person : UserAbstract
    {
        public override DateTime BirthDay
        {
            get => base.BirthDay;
            set
            {
                base.BirthDay = value;
                Calc();
            }
        }
        public override int? Calc()
        {
            Age = DateTime.Now.Year - BirthDay.Year;
            return Age > 120 || Name == string.Empty ? null : Age;
        }
        public override string ToString()
        {
            return DateTime.Now + " Name: " + Name + " BirthDay:" + BirthDay;
        }
    }
}