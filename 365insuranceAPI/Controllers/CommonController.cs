using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using VICAInsurance.Services.Services;
using VICAInsurance.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VICAInsuranceAPI.Controllers
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
        [HttpGet("GetVehicleInsuranceCompanies")]
        public async Task<List<VehicleInsuranceCompany>> GetVehicleInsuranceCompanies()
        {
            return await _commonService.GetVehicleInsuranceCompanies();
        }

        [HttpGet("GetAllMasters")]
        public async Task<AllMastersModel> GetAllMasters()
        {
            return await _commonService.GetAllMasters();
        }

        [HttpGet("GetClaimSupport")]
        public async Task<List<ClaimSupportModel>> GetClaimSupport()
        {
            return await _commonService.GetClaimSupport();
        }

        [HttpGet("GetMonthlyGrid")]
        public async Task<List<MonthlyGridModel>> GetMonthlyGrid()
        {
            return await _commonService.GetMonthlyGrid();
        }

        [HttpPost("GetPolicyCopy")]
        public async Task<List<PolicyCopy>?> GetPolicyCopy([FromBody] PolicyCopySearch model)
        {
            List<PolicyCopy>? data = new List<PolicyCopy>();
            try
            {
                data = await _commonService.GetPolicyCopy(model);

            }
            catch (Exception ex)
            {
                return data;
            }
            return data;

        }
    }
}
