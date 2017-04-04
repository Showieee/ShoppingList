using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Database;
using WebService.Models;

namespace TestingEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PostgreSQLContext ctx = new PostgreSQLContext())
            {
                UserInfo user = new UserInfo();
                user.Username = "antochsi";
                user.PasswordHash = "parolameasmechera";
                user.FirstName = "Silviu";

                DeliveryLocation site = new DeliveryLocation();
                site.Name = "Sacele";
                site.Address = "Bunloc 1, Sediu CIBIN";

                ProductRequest request = new ProductRequest();
                request.Item = "Mancare";
                request.DeliveryLocation = site;
                request.FulfilledByDriver = user;

                ctx.ProductRequests.Add(request);
                ctx.SaveChanges();

            }
        }
    }
}
