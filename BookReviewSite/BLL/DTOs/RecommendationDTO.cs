using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RecommendationDTO
    {
        public int RecommendationId { get; set; }
        public string Username { get; set; }
        public int BookId { get; set; }
        public bool IsRecommended { get; set; }
        public DateTime RecommendationDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
