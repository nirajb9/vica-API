using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using VICAInsurance.Services.Services;
using VICAInsurance.Services.ViewModels;

namespace VICAInsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PolicyCopyController : ControllerBase
    {
        private readonly ICommonService _commonService;
        private readonly IPolicyCopyService _policyCopyService;

        public PolicyCopyController(ICommonService commonService, IPolicyCopyService policyCopyService)
        {
            _commonService = commonService;
            _policyCopyService = policyCopyService;
        }
        [HttpGet("GetPolicyCopy")]
        public async Task<List<PolicyCopyModel>> GetPolicyCopy()
        {
            var data = await _policyCopyService.GetPolicyCopy();
            return data;
        }

        [HttpPost("SavePolicyCopy")]
        public async Task<IActionResult> SavePolicyCopy([FromBody] PolicyCopyModel model)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                rr = await _policyCopyService.SavePolicyCopy(model);

            }
            catch (Exception ex)
            {

                return Ok(rr);
            }
            return Ok(rr);
        }
    }

}
