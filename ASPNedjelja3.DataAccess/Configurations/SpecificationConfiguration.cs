using ASPNedjelja3Vjezbe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.DataAccess.Configurations
{
    public class SpecificationConfiguration : EntityConfiguration<Specification>
    {
        protected override void ConfigurationRules(EntityTypeBuilder<Specification> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasMany(x => x.SpecificationValues).WithOne(x => x.Specification).HasForeignKey(x => x.SpecificationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
