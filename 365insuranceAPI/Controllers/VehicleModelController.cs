using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VICAInsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService _vehicleModelService;

        public VehicleModelController(IVehicleModelService vehicleModelService)
        {
            _vehicleModelService = vehicleModelService;
        }

        [HttpGet]
        public Task<List<VehicleModel>> GetAllVehicleModel()
        {
            return _vehicleModelService.GetAllVehicleModel();
        }

        [HttpGet("GetVehicleModelById/{id}")]
        public Task<VehicleModel> GetVehicleModelById(int id)
        {
            return _vehicleModelService.GetVehicleModelById(id);
        }

        [HttpPost]
        public async Task<int> AddVehicleModel([FromBody] VehicleModel vehicleInfo)
        {
            return await _vehicleModelService.AddVehicleModel(vehicleInfo);
        }

        [HttpPut("UpdateVehicleModel")]
        public void UpdateVehicleModel([FromBody] VehicleModel vehicleInfo)
        {
            _vehicleModelService.UpdateVehicleModel(vehicleInfo);
        }

        [HttpDelete("DeleteVehicleModel/{id}")]
        public void DeleteVehicleModel(int id)
        {
            _vehicleModelService.DeleteVehicleModel(id);
        }
        [HttpGet("GetVehicleModelByCompanyId/{id}")]
        public Task<List<VehicleModel>> GetVehicleModelByCompanyId(int id)
        {
            return _vehicleModelService.GetVehicleModelByCompanyId(id);
        }
    }
}
