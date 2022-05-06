using System.Net.Mime;

using Microsoft.AspNetCore.Mvc;

using Generations.Data.Contracts;
using Generations.ObjectModel;

namespace Generations.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(
            ILogger<PersonController> logger,
            IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public ActionResult<Person> GetById([FromRoute] long id)
        {
            try
            {
                return _personService.GetById(id);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Person> Create([FromBody] Person person)
        {
            try
            {
                person = _personService.Create(person);

                return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                return BadRequest();
            }
        }
    }
}