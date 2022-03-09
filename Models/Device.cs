using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Device
    {
        [Key]
        public string DeviceGuid { get; set; }
        List<SensorData> Sensors;
        User User;
    }
}