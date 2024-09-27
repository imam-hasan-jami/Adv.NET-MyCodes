using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
        public AuthorDTO Author { get; set; }
    }
}
