using ASPNedjelja3Vjezbe.Application.UseCases.DTO;
using ASPNedjelja3Vjezbe.Application.UseCases.DTO.Searches;
using ASPNedjelja3Vjezbe.Application.UseCases.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.Implementation.UseCases.Queries.SP
{
    public class SPGetCategoriesQuery : IGetCategoriesQuery
    {
        public int Id => 2;

        public string Name => "SP Search Categories";

        public string Description => "";

        public IEnumerable<CategoryDTO> Execute(BaseSearch search)
        {
            var conn = new SqlConnection("Data Source=NEMANJA\\SQLEXPRESS;Initial Catalog=AspVjezbe;Integrated Security=True");
            var result = conn.Query<CategoryDTO>("SearchCategories", new { search.Keyword }, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
