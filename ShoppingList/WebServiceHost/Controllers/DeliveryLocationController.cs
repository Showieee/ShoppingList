using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Entities;
using WebServiceHost.Database;
using WebServiceHost.Entities;

namespace WebServiceHost.Controllers
{
    public class DeliveryLocationController : ApiController
    {
        [HttpGet]
        [ActionName("Sites")]
        public IEnumerable<DeliveryLocation> GetAllDeliveryLocations()
        {
            if (!ModelState.IsValid)
                return null;

            using (MainDbContext context = new MainDbContext())
            {
                try
                {
                    return
                    (
                    from site in context.DeliverySites
                    select new DeliveryLocation()
                    {
                        ID = site.ID,
                        Name = site.Name,
                        Address = site.Address
                    }
                    ).ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        [HttpPost]
        [ActionName("New")]
        [ResponseType(typeof(int))]
        public int AddNewDeliveryLocation([FromBody]DeliveryLocation location)
        {
            if (!ModelState.IsValid)
                return 0;

            using (MainDbContext context = new MainDbContext())
            {
                try
                {
                    DeliverySite site = new DeliverySite();
                    site.Name = location.Name;
                    site.Address = location.Address;

                    context.DeliverySites.Add(site);
                    context.SaveChanges();

                    return site.ID;
                }
                catch
                {
                    return 0;
                }
            }
        }

        [HttpPost]
        [ActionName("Edit")]
        [ResponseType(typeof(bool))]
        public bool EditDeliveryLocation([FromBody]DeliveryLocation location)
        {
            if (!ModelState.IsValid)
                return false;

            using (MainDbContext context = new MainDbContext())
            {
                try
                {
                    var existingDeliverySite = context.DeliverySites.FirstOrDefault(site => site.ID == location.ID);

                    context.Entry(existingDeliverySite).State = EntityState.Modified;

                    existingDeliverySite.Name = location.Name;
                    existingDeliverySite.Address = location.Address;

                    context.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        [HttpDelete]
        [ActionName("Remove")]
        [ResponseType(typeof(bool))]
        public bool DeleteDeliveryLocation(int id)
        {
            if (!ModelState.IsValid)
                return false;

            using (MainDbContext context = new MainDbContext())
            {
                try
                {
                    DeliverySite site = context.DeliverySites.FirstOrDefault(ds => ds.ID == id);
                    context.DeliverySites.Remove(site);

                    context.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
