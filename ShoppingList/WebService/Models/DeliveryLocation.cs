using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    [Table("delivery_locations", Schema = "public")]
    public class DeliveryLocation
    {
        [Key]
        [Required]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("address")]
        public string Address { get; set; }

        public virtual ICollection<ProductRequest> Products { get; set; }

        public DeliveryLocation()
        {
            Products = new HashSet<ProductRequest>();
        }
    }
}