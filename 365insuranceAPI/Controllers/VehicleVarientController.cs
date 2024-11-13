using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using VICAInsurance.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VICAInsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleVarientController : ControllerBase
    {
        private readonly IVehicleVariantService _vehicleVariantService;

        public VehicleVarientController(IVehicleVariantService vehicleVariantService)
        {
            _vehicleVariantService = vehicleVariantService;
        }

        [HttpGet]
        public Task<List<VehicleVariant>> GetAllVehicleVariant()
        {
            return _vehicleVariantService.GetAllVehicleVariant();
        }

        [HttpGet("GetVehicleVariantById/{id}")]
        public Task<VehicleVariant> GetVehicleVariantById(int id)
        {
            return _vehicleVariantService.GetVehicleVariantById(id);
        }

        [HttpPost]
        public async Task<int> AddVehicleVariant([FromBody] VehicleVariant vehicleVariant)
        {
            return await _vehicleVariantService.AddVehicleVariant(vehicleVariant);
        }

        [HttpPut("UpdateVehicleVariant")]
        public void UpdateVehicleVariant([FromBody] VehicleVariant vehicleVariant)
        {
            _vehicleVariantService.UpdateVehicleVariant(vehicleVariant);
        }

        [HttpDelete("DeleteVehicleVariant/{id}")]
        public void DeleteVehicleVariant(int id)
        {
            _vehicleVariantService.DeleteVehicleVariant(id);
        }
        [HttpGet("GetVehicleVariantByModelId/{id}")]
        public Task<List<VehicleVariant>> GetVehicleVariantByModelId(int id)
        {
            return _vehicleVariantService.GetVehicleVariantByModelId(id);
        }
    }
}
