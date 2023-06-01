using ASPNedjelja3.DataAccess;
using ASPNedjelja3Vjezbe.Api.DTO;
using ASPNedjelja3Vjezbe.Api.DTO.Searches;
using ASPNedjelja3Vjezbe.Application.Logging;
using ASPNedjelja3Vjezbe.Domain;
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

            logger.Log(e);

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
        public IActionResult Post([FromBody] CreateSpecificationDTO dto)
        {
            try
            {
                var errors = new List<string>();
                if (string.IsNullOrEmpty(dto.Name))
                {
                    errors.Add("Name is required paramater.");
                }
                else
                {
                    if (context.Specifications.Any(x => x.Name == dto.Name))
                    {
                        errors.Add("Specification with this name already exists");
                    }
                    else
                    {
                        if (dto.Values.Count() != dto.Values.Distinct().Count())
                        {
                            errors.Add("Duplicatetd elements are not allowed");
                        }
                    }
                }

                if (dto.Values != null && dto.Values.Any())
                {
                    if (dto.Values.Any(x => string.IsNullOrEmpty(x)))
                    {
                        errors.Add("There are empty epecifications");
                    }
                }

                if (errors.Any())
                {
                    return UnprocessableEntity(errors);
                }
                var specification = new Specification
                {
                    Name = dto.Name,
                    SpecificationValues = dto.Values.Select(x => new SpecificationValue
                    {
                        Value = x,
                    }).ToList()
                };
                context.Specifications.Add(specification);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
                throw;
            }
        }

        // PUT api/<SpecificationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpecificationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var specification = context.Specifications.Find(id);
                if (specification == null || !specification.IsActive)
                {
                    return NotFound();
                }
                var categorySpec = specification.CategorySpecifications;
                context.CategorySpecifications.RemoveRange(categorySpec);
                
                var values=specification.SpecificationValues;
                context.SpecificationValues.RemoveRange(values);
                context.Specifications.Remove(specification);

                context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return HandleError(ex);
                throw;
            }
        }
    }
}
