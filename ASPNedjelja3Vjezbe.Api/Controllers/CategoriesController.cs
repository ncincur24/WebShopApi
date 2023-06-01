using ASPNedjelja3Vjezbe.Application.UseCases.Commands;
using ASPNedjelja3Vjezbe.Application.UseCases.DTO;
using ASPNedjelja3Vjezbe.Application.UseCases.DTO.Searches;
using ASPNedjelja3Vjezbe.Application.UseCases.Queries;
using ASPNedjelja3Vjezbe.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNedjelja3Vjezbe.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private UseCaseHandler handler;

        public CategoriesController(UseCaseHandler handler)
        {
            this.handler = handler;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetCategoriesQuery query)
        {
            return Ok(handler.HandleQuery(query, search));
        }

        public IActionResult Post([FromBody]CreateCategoryDTO dto, [FromServices] ICreateCategoryCommand command)
        {
            try
            {
                handler.HandleCommand(command, dto);
                return StatusCode(201);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
