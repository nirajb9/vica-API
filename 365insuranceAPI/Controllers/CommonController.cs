using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.IServices;
using _365Insurance.Services.Services;
using _365Insurance.Services.ViewModels;
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
        [HttpPost("GetPaymentLink")]
        public async Task<List<PolicyPaymentLink>> GetPaymentLink([FromBody] SearchParam searchParam)
        {
            return await _commonService.GetPaymentLink(searchParam);
        }
        [HttpPost("GetSurveyLink")]
        public async Task<List<PolicySurveyLink>> GetSurveyLink([FromBody] SearchParam searchParam)
        {
            return await _commonService.GetSurveyLink(searchParam);
        }
        [HttpPost("GetPolicyCashback")]
        public async Task<List<PolicyCashback>> GetPolicyCashback([FromBody] SearchParam searchParam)
        {
            return await _commonService.GetPolicyCashback(searchParam);
        }
        [HttpPost("GetPolicyType")]
        public async Task<List<PolicyType>> GetPolicyType([FromBody] SearchParam searchParam)
        {
            return await _commonService.GetPolicyType(searchParam);
        }

        [HttpPost("GetCompanySliders")]
        public async Task<CompanySlider> GetCompanySliders([FromBody] SearchParam searchParam)
        {
            return await _commonService.GetCompanySliders(searchParam);
        }

    }
}
