using ApiStudy.Data.DTO;
using ApiStudy.Model;
using ApiStudy.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonServices _personService;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonServices personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all persons");
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Getting person by ID {id}", id);
            var person = _personService.FindById(id);
            if (person == null)
            {
                _logger.LogWarning("Person with ID {id} not found", id);
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Creating {FirstName} {LastName}", [person.FirstName, person.LastName]);
            var createdPerson = _personService.Create(person);
            if (createdPerson == null)
            {
                _logger.LogError("Failed to create person {FirstName} {LastName}", [person.FirstName, person.LastName]);
                return NotFound();
            }
            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Updating {FirstName} {LastName}", [person.FirstName, person.LastName]);
            var createdPerson = _personService.Update(person);
            if (createdPerson == null)
            {
                _logger.LogError("Failed to update person {FirstName} {LastName}", [person.FirstName, person.LastName]);
                return NotFound();
            }
            _logger.LogDebug("Updated person details: {FirstName}", createdPerson.FirstName);
            return Ok(createdPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting {id}", id);
            _personService.Delete(id);
            _logger.LogDebug("Deleted person with ID {id}", id);
            return NoContent();
        }
    }
}
