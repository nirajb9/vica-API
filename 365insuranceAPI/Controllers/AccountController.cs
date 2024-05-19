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
        public async Task<ActionResult<UserRegistration>> Register(UserRegistrationModel registerDto)
        {
            if (await UserExists(registerDto.Email)) return BadRequest("UserName Is Already Taken");
            var hmac = new HMACSHA512();

            var user = new UserRegistration
            {
                Name = registerDto.Name.ToLower(),
                Email = registerDto.Email,
                MobileNo = registerDto.MobileNo,
                Isapproved = true,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,

            };

            _context.UserRegistrations.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDetails>> Login(LoginModel loginDto)
        {
            var user = await _context.UserRegistrations
                .SingleOrDefaultAsync(x => x.Email == loginDto.Email);

            if (user == null) return Unauthorized("Invalid UserName");

            var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }

            return new UserDetails
            {
                Email = user.Email,
                Name = user.Name,
                MobileNo = user.MobileNo,
                Token = _tokenService.CreateToken(user)
            };


        }


        private async Task<bool> UserExists(string email)
        {
            return await _context.UserRegistrations.AnyAsync(x => x.Email.ToLower() == email.ToLower());
        }

        [HttpGet("getuserdetails")]
        public async Task<List<UserRegistration>> GetUserDetails()
        {
            return await _registrationService.GetUserDetails();
        }


    }
}
