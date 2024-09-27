using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AuthorWithBooksDTO : AuthorDTO
    {
        public List<BookSummaryDTO> Books { get; set; }
        public AuthorWithBooksDTO()
        {
            Books = new List<BookSummaryDTO>();
        }
    }
}
