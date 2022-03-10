using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Device
    {
        [Key]
        public string DeviceGuid { get; set; }
        public List<SensorData> SensorMeasurements { get; set; }
        public User User { get; set; }
        public Plant CurrentPlant { get; set; }
        public int WaterTankLevel { get; set; }
        public int FertilizerLevel { get; set; }
    }
}