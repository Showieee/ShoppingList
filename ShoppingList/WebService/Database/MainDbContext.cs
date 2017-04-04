using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebService.Models;

namespace WebService.Database
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
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LoginInfo> LoginInfo { get; set; }

        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<ProductRequest> ProductRequests { get; set; }

        public DbSet<DeliveryLocation> DeliveryLocations { get; set; }
    }
}