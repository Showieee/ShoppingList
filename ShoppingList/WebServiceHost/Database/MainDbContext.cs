using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using WebServiceHost.Entities;

namespace WebServiceHost.Database
{
    public class MainDbContext : DbContext
    {
        public MainDbContext() : base(nameOrConnectionString: "PostgreSQLConnectionString")
        {
            System.Data.Entity.Database.SetInitializer<MainDbContext>(null);
        }

        public MainDbContext(string connectionString) : base(nameOrConnectionString: connectionString)
        {
            System.Data.Entity.Database.SetInitializer<MainDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<LoginInfo>()
                .ToTable("login_info", "public")
                .HasKey(e => e.ID)
                .HasRequired(li => li.UserInfo).WithRequiredPrincipal(ui => ui.LoginInfo);

            modelBuilder.Entity<LoginInfo>()
                .Property(e => e.ID).IsRequired().HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<LoginInfo>()
                .Property(e => e.Username).IsRequired().HasColumnName("username");
            modelBuilder.Entity<LoginInfo>()
                .Property(e => e.Password).IsRequired().HasColumnName("password");

            modelBuilder.Entity<UserInfo>()
                .ToTable("user_info", "public")
                .HasKey(e => e.ID);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.ID).IsRequired().HasColumnName("id");
            modelBuilder.Entity<UserInfo>()
                .Property(e => e.FirstName).IsRequired().HasColumnName("first_name");
            modelBuilder.Entity<UserInfo>()
                .Property(e => e.LastName).IsOptional().HasColumnName("last_name");
            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Telephone).IsOptional().HasColumnName("telephone");
            modelBuilder.Entity<UserInfo>()
                .Property(e => e.IsDriver).IsRequired().HasColumnName("is_driver");

            modelBuilder.Entity<DeliverySite>()
                .ToTable("delivery_locations", "public")
                .HasKey(e => e.ID);

            modelBuilder.Entity<DeliverySite>()
                .Property(e => e.ID).IsRequired().HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<DeliverySite>()
                .Property(e => e.Name).IsRequired().HasColumnName("name");
            modelBuilder.Entity<DeliverySite>()
                .Property(e => e.Address).IsOptional().HasColumnName("address");

            modelBuilder.Entity<ProductRequest>()
                .ToTable("product_requests", "public")
                .HasKey(e => e.ID);

            modelBuilder.Entity<ProductRequest>()
                .HasRequired(e => e.DeliverySite).WithMany(l => l.Products).HasForeignKey(e => e.SiteId).WillCascadeOnDelete();
            modelBuilder.Entity<ProductRequest>()
                .HasOptional(e => e.RequestAssignment).WithRequired(upra => upra.ProductRequest).WillCascadeOnDelete();

            modelBuilder.Entity<ProductRequest>()
                .Property(e => e.ID).IsRequired().HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ProductRequest>()
                .Property(e => e.Item).IsRequired().HasColumnName("item");
            modelBuilder.Entity<ProductRequest>()
                .Property(e => e.Amount).IsOptional().HasColumnName("amount");
            modelBuilder.Entity<ProductRequest>()
                .Property(e => e.Details).IsOptional().HasColumnName("details");
            modelBuilder.Entity<ProductRequest>()
                .Property(e => e.IsDelivered).IsRequired().HasColumnName("is_delivered");
            modelBuilder.Entity<ProductRequest>()
                .Property(e => e.SiteId).IsRequired().HasColumnName("site_id");

            modelBuilder.Entity<UserProductRequestAssigment>()
                .ToTable("user_request_assignments", "public")
                .HasKey(e => e.ProductRequestId);

            modelBuilder.Entity<UserProductRequestAssigment>()
                .HasRequired(e => e.User).WithMany(ui => ui.UserAssignments).HasForeignKey(ui => ui.UserId);

            modelBuilder.Entity<UserProductRequestAssigment>()
                .Property(e => e.ProductRequestId).IsRequired().HasColumnName("request_id");
            modelBuilder.Entity<UserProductRequestAssigment>()
                .Property(e => e.UserId).IsRequired().HasColumnName("user_id");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LoginInfo> LoginInfo { get; set; }

        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<ProductRequest> ProductRequests { get; set; }

        public DbSet<DeliverySite> DeliverySites { get; set; }

        public DbSet<UserProductRequestAssigment> RequestAssignments { get; set; }
    }
}
