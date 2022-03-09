using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Account
    {
        [Key]
        public Guid UserId { get; set; }
        List<Device> devices;
        User user;
    }
}