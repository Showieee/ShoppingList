namespace Entities
{
    public class Product
    {
        public int ID { get; set; }

        public string Item { get; set; }

        public string Amount { get; set; }

        public string Details { get; set; }

        public DeliveryLocation Site { get; set; }

        public bool IsDelivered { get; set; }
    }
}
