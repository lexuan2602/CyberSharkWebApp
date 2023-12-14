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
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Blog> Blog { get; set; }
        
        public DbSet<Order> Order { get; set; }
        
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Voucher> Voucher { get; set; }
        public DbSet<VoucherOrders> VoucherOrder { get; set; }



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
