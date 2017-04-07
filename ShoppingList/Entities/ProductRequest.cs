namespace Entities
{
    public class ProductRequest
    {
        public int ID { get; set; }

        public string Item { get; set; }

        public string Amount { get; set; }

        public string Details { get; set; }

        public int SiteId { get; set; }

        public bool IsDelivered { get; set; }

        public virtual DeliveryLocation DeliveryLocation { get; set; }

        public virtual UserProductRequestAssigment RequestAssignment { get; set; }
    }
}