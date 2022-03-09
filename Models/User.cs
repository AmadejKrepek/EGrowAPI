using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Key]
        public string UserGuid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Device> Devices { get; set; }
    }
}
