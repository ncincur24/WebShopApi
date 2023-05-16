﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.Domain
{
    public class Image : Entity
    {
        public string Path { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
