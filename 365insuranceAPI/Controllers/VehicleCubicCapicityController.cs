using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _365insuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehicleCubicCapicityController : ControllerBase
    {
        private readonly IVehicleCubicCapicityService _vehicleCubicCapicityService;

        public VehicleCubicCapicityController(IVehicleCubicCapicityService vehicleCubicCapicityService)
        {
            _vehicleCubicCapicityService = vehicleCubicCapicityService;
        }

        [HttpGet("GetAllVehicleCubicCapicity")]
        public Task<List<VehicleCubicCapicity>> GetAllVehicleCubicCapicity()
        {
            return _vehicleCubicCapicityService.GetAllVehicleCubicCapicity();
        }

        [HttpGet("GetVehicleCubicCapicityById/{id}")]
        public Task<VehicleCubicCapicity> GetVehicleCubicCapicityById(int id)
        {
            return _vehicleCubicCapicityService.GetVehicleCubicCapicityById(id);
        }

        [HttpPost]
        public async Task<int> AddVehicleCubicCapicity([FromBody] VehicleCubicCapicity vehicleInfo)
        {
            return await _vehicleCubicCapicityService.AddVehicleCubicCapicity(vehicleInfo);
        }

        [HttpPut("UpdateVehicleCubicCapicity")]
        public void UpdateVehicleCubicCapicity([FromBody] VehicleCubicCapicity vehicleInfo)
        {
            _vehicleCubicCapicityService.UpdateVehicleCubicCapicity(vehicleInfo);
        }

        [HttpDelete("DeleteVehicleCubicCapicity/{id}")]
        public void DeleteVehicleCubicCapicity(int id)
        {
            _vehicleCubicCapicityService.DeleteVehicleCubicCapicity(id);
        }

        [HttpGet("GetAllVehicleCubicCapicityByVT/{id}")]
        public Task<List<VehicleCubicCapicity>> GetAllVehicleCubicCapicityByVT(int id)
        {
            return _vehicleCubicCapicityService.GetAllVehicleCubicCapicityByVT(id);
        }

    }
}
