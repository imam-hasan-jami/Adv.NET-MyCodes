using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class ReviewVote
    {
        public int ReviewVoteId { get; set; }
        [Required]
        [ForeignKey("User")]
        public string Username { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey("Review")]
        public int ReviewId { get; set; }
        public Review Review { get; set; }

        [Required]
        public bool IsUpvote { get; set; }

        [Required]
        public DateTime VoteDate { get; set; } = DateTime.Now;
    }
}


