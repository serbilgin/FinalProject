using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthWindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=NorthwindTest; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserOperationClaim>()
                .HasKey(uoc => uoc.Id);
            modelBuilder.Entity<UserOperationClaim>()
                .HasAlternateKey(uoc => new { uoc.UserId, uoc.OperationClaimId });
            modelBuilder.Entity<UserOperationClaim>()
                .HasOne(uoc => uoc.User)
                .WithMany(u => u.UserOperationClaims)
                .HasForeignKey(uoc => uoc.UserId);
            modelBuilder.Entity<UserOperationClaim>()
                .HasOne(uoc => uoc.OperationClaim)
                .WithMany(oc => oc.UserOperationClaims)
                .HasForeignKey(uoc => uoc.OperationClaimId);

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<User>().Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<User>().Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(80);
            modelBuilder.Entity<User>().Property(u => u.PasswordHash)
                .IsRequired();
            modelBuilder.Entity<User>().Property(u => u.PasswordSalt)
                .IsRequired();

            modelBuilder.Entity<OperationClaim>().HasKey(o => o.Id);
            modelBuilder.Entity<OperationClaim>().Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(60);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);
            modelBuilder.Entity<Order>().HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
            modelBuilder.Entity<Customer>().Property(c => c.ContactName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Product>().Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(40);
            modelBuilder.Entity<Product>().Property(p => p.UnitPrice)
                .IsRequired();
            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<Category>().Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(40);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
