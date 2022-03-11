using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EGrowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorDetailsController : ControllerBase
    {
        private readonly MySqlContext _context;

        public SensorDetailsController(MySqlContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<SensorDetail>> SensorDetail(string userGuid, int sensorDataId)
        {
            try
            {
                var foundDevice = await _context.Devices.Include(device => device.SensorMeasurements)
                .ThenInclude(data => data.Plant)
                .SingleAsync(device => device.SensorMeasurements.Any(data => data.SensorDataId == sensorDataId));

                var foundData = foundDevice.SensorMeasurements.Single(data => data.SensorDataId == sensorDataId);
                SensorDetail details = new SensorDetail();
                details.SensorDataId = foundData.SensorDataId;
                details.Timestamp = foundData.Timestamp;
                details.SoilTemperatureCelsius = foundData.SoilTemperatureCelsius;
                details.AmbientTemperatureCelsius = foundData.AmbientTemperatureCelsius;
                details.UvIndex = foundData.UvIndex;
                details.SolarRadiation = foundData.SolarRadiation;
                details.LeafWetness = foundData.LeafWetness;
                details.AmbientHumidityPercentage = foundData.AmbientHumidityPercentage;
                details.SoilHumidityPercentage = foundData.SoilHumidityPercentage;
                details.GrowthCm = foundData.GrowthCm;
                details.Device = foundData.Device;
                details.Plant = foundData.Plant;

                return Ok(details);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}