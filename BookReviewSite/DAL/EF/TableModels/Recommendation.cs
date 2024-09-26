using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Recommendation
    {
        public int RecommendationId { get; set; }

        [Required]
        [ForeignKey("User")]
        public string Username { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Required]
        public bool IsRecommended { get; set; }
        public DateTime RecommendationDate { get; set; } = DateTime.Now;
    }
}
