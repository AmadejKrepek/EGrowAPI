using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Column("UserGuid", TypeName = "TEXT")]
        public string UserGuid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Device> Devices { get; set; }
        public DateTime UserRegistration { get; set; }
    }
}
