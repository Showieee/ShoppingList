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
            using (MainDbContext ctx = new MainDbContext())
            {
                LoginInfo loginInfo = new LoginInfo();
                loginInfo.Username = "antochsi";
                loginInfo.Password = "parolameasmechera";

                UserInfo userInfo = new UserInfo();
                userInfo.FirstName = "Silviu";
                userInfo.LoginInfo = loginInfo;

                DeliveryLocation site = new DeliveryLocation();
                site.Name = "Sacele";
                site.Address = "Bunloc 1, Sediu CIBIN";

                ProductRequest request = new ProductRequest();
                request.Item = "Mancare";
                request.DeliveryLocation = site;
                request.FulfilledByDriver = userInfo;

                ctx.ProductRequests.Add(request);
                ctx.SaveChanges();

            }
        }
    }
}
