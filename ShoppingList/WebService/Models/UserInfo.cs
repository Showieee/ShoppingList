using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    [Table("user_info", Schema = "public")]
    public class UserInfo
    {
        [Key]
        [Required]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("telephone")]
        public string Telephone { get; set; }

        [Required]
        [Column("is_driver")]
        public bool IsDriver { get; set; }

        public virtual ICollection<ProductRequest> Products { get; set; }

        public virtual ICollection<LoginInfo> LoginInfo { get; set; }

        public UserInfo()
        {
            Products = new HashSet<ProductRequest>();
        }
    }
}