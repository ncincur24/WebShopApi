using ASPNedjelja3.DataAccess;
using ASPNedjelja3Vjezbe.Application.UseCases.DTO;
using ASPNedjelja3Vjezbe.Application.UseCases.DTO.Searches;
using ASPNedjelja3Vjezbe.Application.UseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.Implementation.UseCases.Queries.Ef
{
    public class EfGetCategoriesQuery : EfUseCase, IGetCategoriesQuery
    {
        public EfGetCategoriesQuery(Vjezbe3DbContext context) : base(context) { }

        public int Id => 1;

        public string Name => "Search Categories";

        public string Description => "Search Categories using Entity Framework";

        public IEnumerable<CategoryDTO> Execute(BaseSearch search)
        {
            var query = Context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }

            return query.Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}
