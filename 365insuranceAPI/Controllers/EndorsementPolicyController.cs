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
    public class EndorsementPolicyController : ControllerBase
    {
        private readonly IEndorsementPolicyService _endorsementPolicyService;

        public EndorsementPolicyController(IEndorsementPolicyService endorsementPolicyService)
        {
            _endorsementPolicyService = endorsementPolicyService;
        }

        [HttpGet("GetEndorsementPolicy/{userid}")]
        public Task<List<EndorsementPolicy>> GetEndorsementPolicy(int userid)
        {
            var data = _endorsementPolicyService.GetEndorsementPolicy(userid);
            return data;
        }

        [HttpPost("AddEndorsementPolicyAsync")]
        public ResponseResult AddEndorsementPolicyAsync([FromBody] EndorsementPolicy ep)
        {
            return _endorsementPolicyService.AddEndorsementPolicyAsync(ep);
        }

    }
}
