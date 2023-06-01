using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.Application.UseCases.DTO
{
    public class CategoryDTO : BaseDTO
    {
        public string Name { get; set; }    
    }

    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; } 
    }
}
