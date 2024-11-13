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
   // [Authorize]
    public class CustomerLeadsController : ControllerBase
    {
        private readonly ICustomerLeadsService _customerLeadsService;

        public CustomerLeadsController(ICustomerLeadsService customerLeadsService)
        {
            _customerLeadsService = customerLeadsService;
        }

        [HttpPost("SaveCustomerLeads")]
        public IActionResult SaveCustomerLeads([FromBody] CustomerLead model)
        {
            var data = "";
            try
            {
                data = _customerLeadsService.AddLeads(model);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
            return Ok(data);

        }

        [HttpPost("GetCustomerLead")]
        public async Task<List<CustomerLead>?> GetCustomerLead([FromBody] CustomerLeadSearch model)
        {
            List<CustomerLead>? data = new List<CustomerLead>();
            try
            {
                data = await _customerLeadsService.GetCustomerLead(model);

            }
            catch (Exception ex)
            {
                return data;
            }
            return data;

        }
    }
}
