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
