using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.DTOs
{
    public class SubtaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TId { get; set; }
    }
}