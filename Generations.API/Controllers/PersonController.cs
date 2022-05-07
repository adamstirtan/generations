using System.Net.Mime;

using Microsoft.AspNetCore.Mvc;

using Generations.Core.Extensions;
using Generations.Data.Contracts;
using Generations.ObjectModel;
using Generations.API.Extensions;

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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Person>> GetById([FromRoute] long id)
        {
            try
            {
                return await _personService.GetByIdAsync(id);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll(string sort = "Id", bool ascending = false, bool paged = false, int page = 1, int pageSize = 100)
        {
            try
            {
                if (typeof(Person).HasProperty(sort) is false)
                {
                    sort = "Id";
                }

                if (paged is false)
                {
                    return Ok(await _personService.AllAsync(sort, ascending));
                }

                page = Math.Max(1, page);
                pageSize = Math.Max(1, pageSize);

                return Ok(this.CreatePagedSet(
                    await _personService.AllAsync(sort, ascending, page, pageSize),
                    await _personService.CountAsync(),
                    page, pageSize,
                    sort,
                    ascending));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> Create([FromBody] Person person)
        {
            try
            {
                person = await _personService.CreateAsync(person);

                return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}