using System.Net.Mime;

using Microsoft.AspNetCore.Mvc;

using Generations.API.Contracts;
using Generations.API.Extensions;
using Generations.Core.Extensions;
using Generations.Data.Contracts;
using Generations.ObjectModel;
using Generations.ObjectModel.Search;

namespace Generations.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class PersonController : ControllerBase,
        IRestController<Person>,
        ISearchController<Person, PersonSearch>
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
        public async Task<ActionResult> GetById([FromRoute] long id)
        {
            try
            {
                return Ok(await _personService.GetByIdAsync(id));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,
                    "Error retrieving people: {exception.Message}",
                    exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(string sort = "Id", bool ascending = false, bool paged = false, int page = 1, int pageSize = 100)
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
                _logger.LogError(exception,
                    "Error retrieving people: {exception.Message}",
                    exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Search([FromQuery] PersonSearch search, string sort = "id", bool ascending = true, bool paged = false, int page = 1, int pageSize = 100)
        {
            try
            {
                if (search is null)
                {
                    return BadRequest();
                }

                if (typeof(Person).HasProperty(sort) is false)
                {
                    sort = "id";
                }

                if (paged is false)
                {
                    return Ok(await _personService.SearchAsync(search, sort, ascending));
                }

                page = Math.Max(1, page);
                pageSize = Math.Max(1, pageSize);

                return Ok(this.CreatePagedSet(
                    await _personService.SearchAsync(search, sort, ascending, page, pageSize),
                    await _personService.CountAsync(search),
                    page, pageSize,
                    sort,
                    ascending));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,
                    "Error searching people: {exception.Message}",
                    exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Create([FromBody] Person dto)
        {
            try
            {
                dto = await _personService.CreateAsync(dto);

                return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,
                    "Error creating person: {exception.Message}",
                    exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update([FromRoute] long id, [FromBody] Person dto)
        {
            try
            {
                Person person = await _personService.GetByIdAsync(id);

                if (person is null)
                {
                    return NotFound();
                }

                bool updated = await _personService.UpdateAsync(id, dto);

                if (updated)
                {
                    return Ok(dto);
                }

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,
                    "Error updating person {id}: {exception.Message}",
                    id, exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            try
            {
                Person person = await _personService.GetByIdAsync(id);

                if (person is null)
                {
                    return NotFound();
                }

                bool deleted = await _personService.DeleteAsync(id);

                if (deleted)
                {
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,
                    "Error deleting person {id}: {exception.Message}",
                    id, exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}