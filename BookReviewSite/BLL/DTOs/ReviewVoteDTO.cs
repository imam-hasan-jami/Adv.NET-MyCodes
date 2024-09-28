using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReviewVoteDTO
    {
        public int ReviewVoteId { get; set; }
        public string Username { get; set; }
        public int ReviewId { get; set; }
        public bool IsUpvote { get; set; }
        public DateTime VoteDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
