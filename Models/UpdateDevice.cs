using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class UpdateDevice
    {
        public string DeviceGuid { get; set; }
        public int WaterTankLevel { get; set; }
        public int FertilizerLevel { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }

    }
}