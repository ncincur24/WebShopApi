using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.Domain
{
    public class SpecificationValue : Entity
    {
        public string Value { get; set; }
        public int SpecificationId { get; set; }

        public virtual Specification Specification { get; set; }
    }
}
