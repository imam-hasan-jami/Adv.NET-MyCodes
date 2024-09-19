using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.DTOs
{
    public class PostTagDTO
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int TagId { get; set; }
        public System.DateTime Date { get; set; }
    }
}