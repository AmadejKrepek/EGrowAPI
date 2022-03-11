using System;

namespace Models
{
    public class SensorDetail
    {
        public int SensorDataId { get; set; }
        public DateTime Timestamp { get; set; }
        public double SoilTemperatureCelsius { get; set; }
        public double AmbientTemperatureCelsius { get; set; }
        public int UvIndex { get; set; }
        public int SolarRadiation { get; set; }
        public int LeafWetness { get; set; }
        public int AmbientHumidityPercentage { get; set; }
        public int SoilHumidityPercentage { get; set; }
        public int GrowthCm { get; set; }
        public string DeviceGuid { get; set; }
        public int DeviceId { get; set; }
        public Plant Plant { get; set; }
    }
}