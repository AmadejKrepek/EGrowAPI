using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserGuid { get; set; } = Guid.NewGuid().ToString();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Device> Devices { get; set; }
        public DateTime UserRegistration { get; set; }
    }
}
