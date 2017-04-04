using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    [Table("product_requests", Schema = "public")]
    public class ProductRequest
    {
        [Key]
        [Required]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column("item")]
        public string Item { get; set; }

        [Column("amount")]
        public string Amount { get; set; }

        [Column("details")]
        public string Details { get; set; }

        [Required]
        [Column("is_delivered")]
        public bool IsDelivered { get; set; }

        [Required]
        [Column("site_id")]
        [ForeignKey("DeliveryLocation")]
        public int SiteId { get; set; }

        [Column("fulfilled_by_driver")]
        [ForeignKey("FulfilledByDriver")]
        public int DriverId { get; set; }

        public virtual DeliveryLocation DeliveryLocation { get; set; }

        public virtual User FulfilledByDriver { get; set; }
    }
}