using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    [Table("login_info", Schema = "public")]
    public class LoginInfo
    {
        [Key]
        [Required]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [Column("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}