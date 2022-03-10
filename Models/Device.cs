using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Device
    {
        [Key]
        public int DeviceId { get; set; }
        public string DeviceGuid { get; set; }
        public int WaterTankLevel { get; set; }
        public int FertilizerLevel { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime DeviceManufactured { get; set; }
        public DateTime DeviceRegisteredToUser { get; set; }
        public List<SensorData> SensorMeasurements { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}