using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VICAInsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleCompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public VehicleCompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetAllVehicleCompany/{id}")]
        public Task<List<VehicleCompany>> GetAllVehicleCompany(int id)
        {
            return _companyService.GetAllVehicleCompany(id);
        }

        [HttpGet("GetVehicleCompanyById/{id}")]
        public Task<VehicleCompany> GetVehicleCompanyById(int id)
        {
            return _companyService.GetVehicleCompanyById(id);
        }

        [HttpPost]
        public async Task<int> AddVehicleCompany([FromBody] VehicleCompany vehicleInfo)
        {
            return await _companyService.AddVehicleCompany(vehicleInfo);
        }

        [HttpPut("UpdateVehicleCompany")]
        public void UpdateVehicleCompany([FromBody] VehicleCompany vehicleInfo)
        {
            _companyService.UpdateVehicleCompany(vehicleInfo);
        }

        [HttpDelete("DeleteVehicleCompany/{id}")]
        public void DeleteVehicleCompany(int id)
        {
            _companyService.DeleteVehicleCompany(id);
        }
    }
}
