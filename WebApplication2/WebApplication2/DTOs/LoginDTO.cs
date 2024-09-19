using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Uname { get; set; }
        [Required]
        public string Password { get; set; }
    }
}