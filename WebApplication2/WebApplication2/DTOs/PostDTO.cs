using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WebApplication2.EF;

namespace WebApplication2.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostTime { get; set; }
        public virtual ICollection<CommentsNew> CommentsNews { get; set; }

        public PostDTO()
        {
            CommentsNews = new List<CommentsNew>();
        }
    }
}