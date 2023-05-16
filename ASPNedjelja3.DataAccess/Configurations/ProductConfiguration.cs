using ASPNedjelja3Vjezbe.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.DataAccess.Configurations
{
    public class ProductConfiguration : EntityConfiguration<Product>
    {
        protected override void ConfigurationRules(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(70);

            builder.HasMany(x => x.Images).WithMany(x => x.Products);
        }
    }
}
