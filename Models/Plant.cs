using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Plant
    {
        [Key]
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public string PlantDescription { get; set; }
        public string PlantType { get; set; }
        public string Instructions { get; set; }
        public double OptimalSoilTemperatureCelsius { get; set; }
        public double OptimalAmbientTemperatureCelsius { get; set; }
        public int OptimalUvIndex { get; set; }
        public int OptimalSolarRadiation { get; set; }
        public int OptimalLeafWetness { get; set; }
        public int OptimalAmbientHumidityPercentage { get; set; }
        public int OptimalSoilHumidityPercentage { get; set; }
        public int FullyGrownCm { get; set; }
        public int SensorDataId { get; set; }
        public SensorData SensorMeasurement { get; set; }
    }
}