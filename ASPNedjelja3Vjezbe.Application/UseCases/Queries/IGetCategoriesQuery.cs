﻿using ASPNedjelja3Vjezbe.Application.UseCases.DTO;
using ASPNedjelja3Vjezbe.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.Application.UseCases.Queries
{
    public interface IGetCategoriesQuery : IQuery<BaseSearch, IEnumerable<CategoryDTO>>
    {
    }
}
