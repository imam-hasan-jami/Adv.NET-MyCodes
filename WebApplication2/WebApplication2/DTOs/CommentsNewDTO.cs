using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.DTOs
{
    public class CommentsNewDTO
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}