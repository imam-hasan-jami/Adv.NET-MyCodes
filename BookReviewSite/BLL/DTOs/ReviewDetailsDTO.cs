using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReviewDetailsDTO
    {
        public string BookTitle { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string ReviewText { get; set; }
        public int UpvoteCount { get; set; }
        public int DownvoteCount { get; set; }
        public int Rating { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
    }
}
