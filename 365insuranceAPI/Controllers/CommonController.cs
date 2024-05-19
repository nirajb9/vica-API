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
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;

        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet("GetVehicleFueltypes")]
        public Task<List<VehicleFueltype>> GetVehicleFueltypes()
        {
            return _commonService.GetVehicleFueltypes();
        }

        [HttpGet("GetVehicleType")]
        public Task<List<VehicleType>> GetVehicleType()
        {
            return _commonService.GetVehicleType();
        }

        [HttpGet("GetVehicleAge")]
        public Task<List<VehicleAge>> GetVehicleAge()
        {
            return _commonService.GetVehicleAge();
        }

        [HttpGet("GetState")]
        public Task<List<StateMa>> GetState()
        {
            return _commonService.GetState();
        }
        [HttpGet("GetRTODetails/{id}")]
        public Task<List<RtoMa>> GetRTODetails(int id)
        {
            return _commonService.GetRTODetails(id);
        }


    }
}
