using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using VICAInsurance.Services.Services;
using VICAInsurance.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace VICAInsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }
        [HttpPost]
        public async Task<int> UserRegistrationAdd([FromBody] UserRegistrationModel userRegistrationModel)
        {
            return await _registrationService.AddUserRegistration(userRegistrationModel);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationModel registerDto)
        {
            return Ok(await _registrationService.UserRegistration(registerDto));
        }

        [HttpGet("getuserdetails")]
        public async Task<List<UserRegistration>> GetUserDetails()
        {
            return await _registrationService.GetUserDetails();
        }
    }
}
