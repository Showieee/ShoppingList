using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebService.Models;

namespace WebService.Database
{
    public class PostgreSQLContext : DbContext, IDbContext
    {
        public PostgreSQLContext() : base(nameOrConnectionString: "PostgreSQLConnectionString")
        {
            System.Data.Entity.Database.SetInitializer<PostgreSQLContext>(null);
        }

        public PostgreSQLContext(string connectionString) : base(nameOrConnectionString: connectionString)
        {
            System.Data.Entity.Database.SetInitializer<PostgreSQLContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserInfo> Users { get; set; }

        public DbSet<ProductRequest> ProductRequests { get; set; }

        public DbSet<DeliveryLocation> DeliveryLocations { get; set; }
    }
}