using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.IServices;
using _365Insurance.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace _365insuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Insure247DbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IRegistrationService _registrationService;
        public AccountController(Insure247DbContext context, ITokenService tokenService, IRegistrationService registrationService)
        {
            _context = context;
            _tokenService = tokenService;
            _registrationService = registrationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationModel registerDto)
        {
            try
            {


                if (await UserExists(registerDto.MobileNo, registerDto.AgentCompanyId))
                {
                    return StatusCode(statusCode: 401, "UserName Is Already Taken");
                }

                var hmac = new HMACSHA512();

                var userReg = _context.UserRegistrations.OrderBy(x => x.UserId).LastOrDefault();

                int id = userReg != null ? userReg.UserId +1 : 1;

                var user = new UserRegistration
                {
                    Name = registerDto.Name.ToLower(),
                    Email = registerDto.Email,
                    MobileNo = registerDto.MobileNo,
                    Username =   "IS-" + id,
                    Isapproved = true,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                    PasswordSalt = hmac.Key,
                    AgentCompanyId = registerDto.AgentCompanyId

                };

                _context.UserRegistrations.Add(user);               
                await _context.SaveChangesAsync();
                return StatusCode(statusCode:200, user);
            }
            catch(Exception ex)
            {
                return StatusCode(statusCode: 300, "error");

            }
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


        private async Task<bool> UserExists(string email, int agent_company_id)
        {
            return await _context.UserRegistrations.AnyAsync(x => x.Email.ToLower() == email.ToLower() && x.AgentCompanyId == agent_company_id);
        }

        [HttpGet("getuserdetails")]
        public async Task<List<UserRegistration>> GetUserDetails()
        {
            return await _registrationService.GetUserDetails();
        }


    }
}
