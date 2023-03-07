using CrudAPI.Domain.DTO;
using CrudAPI.Domain.Interfaces.IRepositories;
using CrudAPI.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Application.Service.SQLServerServices
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public List<PersonDTO> FindAll()
        {
            return _personRepository.FindAll()
                .Select(persons => new PersonDTO()
                {
                    id = persons.Id,
                    name = persons.Name,
                    lastName = persons.LastName,
                    age = persons.Age,
                    occupation = persons.Occupation
                }).ToList();
        }

        public async Task<PersonDTO> FindById(int id)
        {
            PersonDTO dto = new PersonDTO();
            return dto.MapToDTO(await _personRepository.FindById(id));
        }

        public Task<int> Save(PersonDTO entityDTO)
        {
            return _personRepository.Save(entityDTO.MapToEntity());
        }

        public Task<int> Update(PersonDTO entityDTO)
        {
            return _personRepository.Update(entityDTO.MapToEntity());
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _personRepository.FindById(id);
            return await _personRepository.Delete(entity);
        }
    }
}
