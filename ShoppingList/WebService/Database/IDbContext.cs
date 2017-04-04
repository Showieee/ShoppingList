using System.Data.Entity;
using WebService.Models;

namespace WebService.Database
{
    public interface IDbContext
    {
        DbSet<DeliveryLocation> DeliveryLocations { get; set; }
        DbSet<ProductRequest> ProductRequests { get; set; }
        DbSet<UserInfo> Users { get; set; }
    }
}