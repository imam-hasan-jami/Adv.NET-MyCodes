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
        public int Rating { get; set; }
    }

    /*public class ReviewDetailsDTO : ReviewDTO
    {
        public List<AuthorDTO> Authors { get; set; }
        public List<BookDTO> Books { get; set; }
        public ReviewDetailsDTO()
        {
            Authors = new List<AuthorDTO>();
            Books = new List<BookDTO>();
        }
    }*/
}
