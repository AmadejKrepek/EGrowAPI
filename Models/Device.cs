using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Device
    {
        [Key]
        public Guid UserId { get; set; }
        List<SensorData> sensors;
        Account account;
    }
}