using ASPNedjelja3.DataAccess;
using ASPNedjelja3Vjezbe.Api.DTO;
using ASPNedjelja3Vjezbe.Api.DTO.Searches;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static ASPNedjelja3Vjezbe.Api.Extensions.StringExtensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNedjelja3Vjezbe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationsController : ControllerBase
    {
        private readonly Vjezbe3DbContext context;
        private readonly IExceptionLogger logger;
        public SpecificationsController(IExceptionLogger logger, Vjezbe3DbContext context)
        {
            this.context = context;
            this.logger = logger;
        }
        // GET: api/<SpecificationController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search)
        {
            try
            {
                //lazy loading
                var query = context.Specifications.Where(x => x.IsActive);

                if (NotNullOrEmpty(search.Keyword))
                {
                    query = query.Where(x => x.Name.Contains(search.Keyword) || x.SpecificationValues.Any(y => y.Value.Contains(search.Keyword)));
                }

                return Ok(query.Select(x => new SpecificationDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    SpecificationValues = x.SpecificationValues.Where(y => y.IsActive).Select(y => new SpecificationValueDTO
                    {
                        Id = y.Id,
                        Value = y.Value,
                    })
                }).ToList());
            }
            catch (Exception e)
            {
                return HandleError(e);
            }
        }

        private IActionResult HandleError(Exception e)
        {
            var guid = Guid.NewGuid();

            logger.LogException(e, guid);

            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "There was an error with proccessing your request. Please reach out to our support using thus code " + guid.ToString() });
        }

        [HttpGet("/api/specificationseager")]
        public IActionResult GetEager([FromQuery] BaseSearch search)
        {
            //eager loading
            var query = context.Specifications.Include(x => x.SpecificationValues).Where(x => x.IsActive);

            if (NotNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword) || x.SpecificationValues.Any(y => y.Value.Contains(search.Keyword)));
            }

            return Ok(query.Select(x => new SpecificationDTO
            {
                Id = x.Id,
                Name = x.Name,
                SpecificationValues = x.SpecificationValues.Where(y => y.IsActive).Select(y => new SpecificationValueDTO
                {
                    Id = y.Id,
                    Value = y.Value,
                })
            }).ToList());
        }

        // GET api/<SpecificationController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //eager loading
            //var specification = context.Specifications.Include(x => x.SpecificationValues).FirstOrDefault(x => x.Id == id && x.IsActive);

            try
            {
                //lazy loading
                var specification = context.Specifications.Find(id);
                if (specification == null || !specification.IsActive)
                {
                    return NotFound();
                }
                return Ok(new SpecificationDTO
                {
                    Id = id,
                    Name = specification.Name,
                    SpecificationValues = specification.SpecificationValues.Select(x => new SpecificationValueDTO
                    {
                        Id = x.Id,
                        Value = x.Value,
                    }).ToList()
                });
            }
            catch (Exception e)
            {
                return HandleError(e);
            }
        }

        // POST api/<SpecificationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SpecificationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpecificationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
