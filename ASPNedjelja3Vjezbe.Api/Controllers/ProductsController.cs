using ASPNedjelja3.DataAccess;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNedjelja3Vjezbe.Api.Controllers
{
    //http://localhost:5026/api/products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get([FromQuery] string keyword)
        {
            var context = new Vjezbe3DbContext();
            var productsQuery = context.Products.AsQueryable();
            if(keyword == null)
            {
                productsQuery = productsQuery.Where(x => x.Name.Contains(keyword));
            }

            return Ok(productsQuery.Select(x => new
            {
                x.Name,
                CategoryName = x.Category.Name,
                x.CategoryId,
                x.Description,
                x.Price,
                Images = x.Images.Select(x => x.Path),
            }).ToList());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
