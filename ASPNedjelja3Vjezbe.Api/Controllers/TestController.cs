using ASPNedjelja3.DataAccess;
using ASPNedjelja3Vjezbe.Domain;
using Bogus;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNedjelja3Vjezbe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/<TestController>
        [HttpGet]
        public IActionResult Get()
        {
            var parentCategories = new List<Category>
            {
                new Category{Name="Category 1"},
                new Category{Name="Category 2"},
                new Category{Name="Category 3"}
            };

            var childCategoriesFaker = new Faker<Category>()
                .RuleFor(c => c.ParentCategory, f => f.PickRandom(parentCategories))
                .RuleFor(x => x.Name, f => f.Commerce.Categories(1).First());
            var fakeCategories = childCategoriesFaker.Generate(100);

            var disitnctNames = fakeCategories.Select(x => x.Name).Distinct();
            var finalCategories = disitnctNames.Select(x => fakeCategories.First(y => y.Name == x)).ToList();
            finalCategories.AddRange(parentCategories);

            var productFaker = new Faker<Product>()
                               .RuleFor(x => x.Name, f => f.Lorem.Word())
                               .RuleFor(x => x.Description, f => f.Lorem.Sentence())
                               .RuleFor(x => x.Price, f => f.Random.Decimal(1, 1000))
                               .RuleFor(x => x.Category, f => f.PickRandom(finalCategories));
            var products = productFaker.Generate(30000);

            var context = new Vjezbe3DbContext();
            context.Products.AddRange(products);
            context.Categories.AddRange(finalCategories);
            context.SaveChanges();

            return NoContent();
        }
    }
}
