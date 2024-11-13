using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using VICAInsurance.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System;

namespace VICAInsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Insure247DbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IRegistrationService _registrationService;
        private readonly Random _random = new Random();
        public AccountController(Insure247DbContext context, ITokenService tokenService, IRegistrationService registrationService)
        {
            _context = context;
            _tokenService = tokenService;
            _registrationService = registrationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationModel registerDto)
        {
            return Ok(await _registrationService.UserRegistration(registerDto));
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDetails>> Login(LoginModel loginDto)
        {
            var user = await _context.UserRegistrations
                .SingleOrDefaultAsync(x => x.Username == loginDto.username);

            if (user == null) return Unauthorized("Invalid UserName");

            var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }
            var agentCompanyDetails = await _context.AgentCompanyRegistrations.Where(s => s.AgentCompanyId == user.AgentCompanyId).FirstOrDefaultAsync();
            return new UserDetails
            {
                UserId = user.UserId,
                Email = user.Email,
                Name = user.Name,
                MobileNo = user.MobileNo,
                Token = _tokenService.CreateToken(user),
                AgentCompanyId = user.AgentCompanyId,
                AgentCompanyName = agentCompanyDetails != null ? agentCompanyDetails.AgentCompanyName : "",
                LogoUrl = agentCompanyDetails != null ? agentCompanyDetails.AgentCompanyLogoUrl : ""
            };


        }
        
        [HttpGet("GetMainCompany")]
        public async Task<MainCompany> GetMainCompany()
        {
            return await _context.MainCompanies.FirstOrDefaultAsync();
        }

        [HttpGet("GetAgentCompanyRegistrations")]
        public async Task<List<AgentCompanyRegistration>> GetAgentCompanyRegistrations()
        {
            return await _context.AgentCompanyRegistrations.Where(s=> s.IsDeleted == false).ToListAsync();
        }

    }
}
