using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using VICAInsurance.Services.ViewModels;

namespace VICAInsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EndorsementController : ControllerBase
    {
        private readonly ICommonService _commonService;
        private readonly IEndorsementService _endorsementService;

        public EndorsementController(ICommonService commonService, IEndorsementService endorsementService)
        {
            _commonService = commonService;
            _endorsementService = endorsementService;
        }
        [HttpGet("GetEndorsementPolicy")]
        public async Task<List<EndorsementModel>> GetEndorsementPolicy()
        {
            var data = await _endorsementService.GetEndorsementPolicy();
            return data;
        }

        [HttpPost("UpdateEndrosmentPolicy")]
        public Task<EndorsementPolicy?> UpdateEndrosmentPolicy([FromBody] EndorsementPolicy model)
        {
            var data = _endorsementService.UpdateEndrosmentPolicy(model);
            return data;
        }
    }
}
