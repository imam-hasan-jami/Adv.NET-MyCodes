using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Uname { get; set; }
        public string Pass { get; set; }
        public string Type { get; set; }
    }
}