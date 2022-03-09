using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Key]
        public string UserGuid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Account Account { get; set; }
    }
}
