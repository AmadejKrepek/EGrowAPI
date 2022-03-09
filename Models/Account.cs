using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Account
    {
        [Key]
        public string UserGuid { get; set; }
        List<Device> devices;
        User user;
    }
}