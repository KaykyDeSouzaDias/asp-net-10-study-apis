using ApiStudy.Data.DTO.V2;
using ApiStudy.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace ApiStudy.Controllers.V2
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private PersonServicesImplV2 _personService;
        private readonly ILogger<PersonController> _logger;

        public PersonController(PersonServicesImplV2 personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
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
    }
}
