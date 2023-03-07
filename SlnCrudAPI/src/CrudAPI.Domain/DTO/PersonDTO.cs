using CrudAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Domain.DTO
{
    public class PersonDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string occupation { get; set; }

        public Person MapToEntity()
        {
            return new Person
            {
                Id = id,
                Name = name,
                LastName = lastName,
                Age = age,
                Occupation = occupation
            };
        }

        public PersonDTO MapToDTO(Person person)
        {
            return new PersonDTO
            {
                id = person.Id,
                name = person.Name,
                lastName = person.LastName,
                age = person.Age,
                occupation = person.Occupation
            };
        }
    }
}
