using ASPNedjelja3Vjezbe.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.DataAccess.Configurations
{
    public class CategoryConfiguration : EntityConfiguration<Category>
    {
        protected override void ConfigurationRules(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(x => x.Name);

            builder.Property(x => x.Name).HasMaxLength(40).IsRequired();

            builder.HasOne(x => x.Image).WithMany().HasForeignKey(x => x.ImageId).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(x => x.ChildCategories).WithOne(x => x.ParentCategory).HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Specifications)
                   .WithOne(x => x.Category)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Products)
                   .WithOne(x => x.Category)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
