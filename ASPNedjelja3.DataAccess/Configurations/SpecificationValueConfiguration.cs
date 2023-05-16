using ASPNedjelja3Vjezbe.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.DataAccess.Configurations
{
    public class SpecificationValueConfiguration : EntityConfiguration<SpecificationValue>
    {
        protected override void ConfigurationRules(EntityTypeBuilder<SpecificationValue> builder) => builder.Property(x => x.Value).IsRequired();
    }
}
