using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [Index(IsUnique = true)]
        public string Email { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
