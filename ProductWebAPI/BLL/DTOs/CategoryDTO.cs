﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [StringLength(10)]
        [Required]
        public string Name { get; set; }
    }
}
