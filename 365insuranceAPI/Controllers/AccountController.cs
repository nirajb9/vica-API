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
        private readonly _247IDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IRegistrationService _registrationService;
        private readonly ILoginService _loginService;
        private readonly Random _random = new Random();
        public AccountController(_247IDbContext context, ITokenService tokenService, IRegistrationService registrationService, ILoginService loginService)
        {
            _context = context;
            _tokenService = tokenService;
            _registrationService = registrationService;
            _loginService = loginService;
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
        [HttpPost("adminlogin")]
        public async Task<ActionResult<UserDetails>> AdminLogin(LoginModel login)
        {
            var user = await _loginService.LoginUser(login, true);
            if(user == null)
            {
                return Unauthorized("Invalid UserName/Password");
            }
            return user;

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
