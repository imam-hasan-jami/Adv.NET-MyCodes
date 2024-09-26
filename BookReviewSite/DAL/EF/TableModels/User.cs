using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class User
    {
        [Key]
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [Index(IsUnique = true)]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.Now;
        public string UserType { get; set; } = "User";
    }
}
