using System.Collections.Generic;

namespace Entities
{
    public class DeliveryLocation
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<ProductRequest> Products { get; set; }

        public DeliveryLocation()
        {
            Products = new HashSet<ProductRequest>();
        }
    }
}