using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Name must be between 4 and 15 characters")]
        public string Name { get; set; }

        [Range(1, 3, ErrorMessage = "CId must be 1, 2, or 3")]
        public int CId { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Markas is required")]
        public string Markas { get; set; }

        [Required(ErrorMessage = "Progress is required")]
        public string Progress { get; set; }
        public List<SubtaskDTO> Subtasks { get; set; }
    }
}