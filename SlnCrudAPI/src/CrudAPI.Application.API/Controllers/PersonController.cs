using CrudAPI.Domain.DTO;
using CrudAPI.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudAPI.Application.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> Get()
        {
            return _personService.FindAll();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDTO>> Get(int id)
        {
            PersonDTO person = new PersonDTO();

            try
            {
                person = await _personService.FindById(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return person;
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<ActionResult<PersonDTO>> Post([FromBody] PersonDTO person)
        {
            await _personService.Save(person);

            return Ok();
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(PersonDTO person)
        {
            await _personService.Update(person);

            return Ok();
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _personService.Delete(id);

            return Ok();
        }
    }
}
