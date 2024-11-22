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

    public class OfflineQuotationController : ControllerBase
    {
        private readonly ICommonService _commonService;
        private readonly IOfflineQuotationService _offlineQuotationService;

        public OfflineQuotationController(ICommonService commonService, IOfflineQuotationService offlineQuotationService)
        {
            _commonService = commonService;
            _offlineQuotationService = offlineQuotationService;
        }

        [HttpPost("SaveOfflineQuotation")]
        public IActionResult SaveOfflineQuotation([FromBody] OfflineQuotationRequest model)
        {
            var data = "";
            try
            {
                data = _offlineQuotationService.Save(model);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
            return Ok(data);

        }

        [HttpPost("SaveOfflinePolicyBuyRequest")]
        public IActionResult SaveOfflinePolicyBuyRequest([FromBody] OfflinePolicyBuyRequest model)
        {
            var data = "";
            try
            {
                data = _offlineQuotationService.SaveOfflinePolicyBuyRequest(model);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
            return Ok(data);
        }

        [HttpGet("GetOfflineQuotation/{userid}")]
        public async Task<List<OfflineQuotationRequestModel>> GetOfflineQuotation(int userid)
        {
            var data = await _offlineQuotationService.GetOfflineQuotation(userid);
            return  data;
        }
        [HttpGet("GetOfflineQuotation")]
        public async Task<List<OfflineQuotationRequestModel>> GetOfflineQuotation()
        {
            var data = await _offlineQuotationService.GetOfflineQuotation();
            return data;
        }

        [HttpGet("GetOfflineQuotationDetails/{userid}/{id}")]
        public async Task<List<OfflineQuotationRequestDetailsModel>> GetOfflineQuotationDetails(int userid, int id)
        {
            var data = await _offlineQuotationService.GetOfflineQuotationDetails(id);
            return data;
        }
    }
}
