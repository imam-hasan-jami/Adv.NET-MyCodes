using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Review
    {
        public int ReviewId { get; set; }
        [Required]
        [ForeignKey("User")]
        public string Username { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public string ReviewText { get; set; }

        public DateTime ReviewDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        //Navigation property
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public Review()
        {
            Authors = new List<Author>();
            Books = new List<Book>();
        }
    }
}
