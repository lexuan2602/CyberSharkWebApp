using Microsoft.EntityFrameworkCore;
using TEST_CRUD.EntityFramework.Extension;

namespace TEST_CRUD.Data
{
    public class CyberSharkContext : DbContext
    {
        public CyberSharkContext(DbContextOptions<CyberSharkContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Brand> Brand { get; set; }
        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    ChangeTracker.SetAuditProperties();
        //    return await base.SaveChangesAsync(cancellationToken);
        //}

        //public override int SaveChanges()
        //{
        //    ChangeTracker.SetAuditProperties();
        //    return base.SaveChanges();
        //}

        //public override int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    ChangeTracker.SetAuditProperties();
        //    return base.SaveChanges(acceptAllChangesOnSuccess);
        //}

        //public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    ChangeTracker.SetAuditProperties();
        //    return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //}
    }
}
