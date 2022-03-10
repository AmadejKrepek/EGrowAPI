using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class SensorData
    {
        [Key]
        public string SensorDataGuid { get; set; }
        public DateTime Timestamp { get; set; }
        public double SoilTemperatureCelsius { get; set; }
        public double AmbientTemperatureCelsius { get; set; }
        public int UvIndex { get; set; }
        public int SolarRadiation { get; set; }
        public int LeafWetness { get; set; }
        public int AmbientHumidityPercentage { get; set; }
        public int SoilHumidityPercentage { get; set; }
        public int GrowthCm { get; set; }
        public Device Device { get; set; }
        public Plant Plant { get; set; }
    }

    public class SensorInput
    {
        public string PlantName { get; set; }
        public string PlantType { get; set; }
        public string IsoDateTimeString { get; set; }
        public double SoilTemperatureCelsius { get; set; }
        public double AmbientTemperatureCelsius { get; set; }
        public int UvIndex { get; set; }
        public int SolarRadiation { get; set; }
        public int LeafWetness { get; set; }
        public int AmbientHumidityPercentage { get; set; }
        public int SoilHumidityPercentage { get; set; }
        public int GrowthCm { get; set; }

        public SensorData ToSensorData()
        {
            return new SensorData
            {
                SensorDataGuid = Guid.NewGuid().ToString(),
                Timestamp = DateTime.Parse(this.IsoDateTimeString),
                SoilTemperatureCelsius = this.SoilTemperatureCelsius,
                AmbientTemperatureCelsius = this.AmbientTemperatureCelsius,
                UvIndex = this.UvIndex,
                SolarRadiation = this.SolarRadiation,
                LeafWetness = this.LeafWetness,
                AmbientHumidityPercentage = this.AmbientHumidityPercentage,
                SoilHumidityPercentage = this.SoilHumidityPercentage,
                GrowthCm = this.GrowthCm
            };
        }
    }
}