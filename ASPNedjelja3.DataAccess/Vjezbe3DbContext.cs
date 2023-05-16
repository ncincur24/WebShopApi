using ASPNedjelja3Vjezbe.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPNedjelja3.DataAccess
{
    public class Vjezbe3DbContext : DbContext
    {
        #region Fields
        public IApplicationUser User { get; }
        #endregion

        #region Constructor
        public Vjezbe3DbContext(IApplicationUser user)
        {
            this.User = user;
        }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<CategorySpecification>().HasKey(x => new { x.CategoryId, x.SpecificationId });
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Data Source=NEMANJA\SQLEXPRESS;Initial Catalog=AspVjezbe;Integrated Security=True").UseLazyLoadingProxies();
        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = User.Identity;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
        #endregion

        #region Tables
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<CategorySpecification> CategorySpecifications { get; set; }
        public DbSet<SpecificationValue> SpecificationValues { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion
    }
}