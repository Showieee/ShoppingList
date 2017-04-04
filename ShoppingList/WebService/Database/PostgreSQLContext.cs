using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebService.Database
{
    public class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext() : base(nameOrConnectionString: "PostgreSQLConnectionString")
        {
            System.Data.Entity.Database.SetInitializer<PostgreSQLContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}