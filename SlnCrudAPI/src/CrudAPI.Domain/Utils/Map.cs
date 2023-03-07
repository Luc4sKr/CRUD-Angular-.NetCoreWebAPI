using CrudAPI.Domain.DTO;
using CrudAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Domain.Utils
{
    public static class Map
    {
        public static PersonDTO PersonMapToDTO(Person person)
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

        public static Person PersonMapToEntity(PersonDTO personDTO)
        {
            return new Person
            {
                Id = personDTO.id,
                Name = personDTO.name,
                LastName = personDTO.lastName,
                Age = personDTO.age,
                Occupation = personDTO.occupation
            };
        }
    }
}
