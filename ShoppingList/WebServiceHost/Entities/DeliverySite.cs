using System.Collections.Generic;

namespace WebServiceHost.Entities
{
    public class DeliverySite
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<ProductRequest> Products { get; set; }

        public DeliverySite()
        {
            Products = new HashSet<ProductRequest>();
        }
    }
}