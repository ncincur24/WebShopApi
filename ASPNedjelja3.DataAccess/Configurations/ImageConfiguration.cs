using ASPNedjelja3Vjezbe.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.DataAccess.Configurations
{
    public class ImageConfiguration : EntityConfiguration<Image>
    {
        protected override void ConfigurationRules(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.Path).HasMaxLength(200).IsRequired(true);
        }
    }
}
