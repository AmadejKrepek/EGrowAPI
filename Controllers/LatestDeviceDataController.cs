using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace EGrowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatestDeviceDataController : ControllerBase
    {
        private readonly MySqlContext _context;

        public LatestDeviceDataController(MySqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DisplaySensorData>>> LatestData(string deviceGuid, string userGuid)
        {
            try
            {
                var foundDevice = await _context.Devices
                .Include(device => device.User)
                .Include(device => device.SensorMeasurements)
                .ThenInclude(data => data.Plant)
                .SingleAsync(device => device.DeviceGuid == deviceGuid);

                if (foundDevice.User.UserGuid != userGuid)
                {
                    return Unauthorized();
                }

                if (foundDevice.SensorMeasurements.Count == 0)
                {
                    return BadRequest("This device has saved no measurements yet.");
                }

                var latestTimestamp = foundDevice.SensorMeasurements.Max(data => data.Timestamp);
                var latestMeasurement = foundDevice.SensorMeasurements.First(data => data.Timestamp == latestTimestamp);
                DisplaySensorData displayData = new DisplaySensorData
                {
                    SensorDataId = latestMeasurement.SensorDataId,
                    Timestamp = latestMeasurement.Timestamp,
                    SoilTemperatureCelsius = latestMeasurement.SoilTemperatureCelsius,
                    AmbientTemperatureCelsius = latestMeasurement.AmbientTemperatureCelsius,
                    UvIndex = latestMeasurement.UvIndex,
                    SolarRadiation = latestMeasurement.SolarRadiation,
                    LeafWetness = latestMeasurement.LeafWetness,
                    AmbientHumidityPercentage = latestMeasurement.AmbientHumidityPercentage,
                    SoilHumidityPercentage = latestMeasurement.SoilHumidityPercentage,
                    GrowthCm = latestMeasurement.GrowthCm,
                    DeviceId=latestMeasurement.Device.DeviceId,
                    Plant = latestMeasurement.Plant
                };
                return Ok(displayData);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return BadRequest("Device not found.");
            }
        }

    }
}