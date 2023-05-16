﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual Category Category { get; set; }
    }
}
