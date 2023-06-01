using ASPNedjelja3.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(Vjezbe3DbContext context)
        {
            Context = context;
        }
        public Vjezbe3DbContext Context { get; set; }
    }
}
