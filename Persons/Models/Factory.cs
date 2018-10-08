using System;

namespace Persons.Models
{
    public interface Factory
    {
        Person Create(string name, DateTime bd);
    }
}
