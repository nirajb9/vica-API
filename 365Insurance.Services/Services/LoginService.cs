using VICAInsurance.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.ViewModels;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace VICAInsurance.Services.Services
{
    public class LoginService: ILoginService
    {
        private readonly _247IDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly Random _random = new Random();

        public LoginService(_247IDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
           
        }
        public async Task<UserDetails?> LoginUser(LoginModel loginDto, bool isAdmin) 
        {
            UserRegistration? user = new UserRegistration();
            if (isAdmin)
            {
                user = await _context.UserRegistrations.Where(x => x.Username == loginDto.username && x.Username == "Vadmin" && x.Isapproved == true && x.IsDeleted == false).FirstOrDefaultAsync();
            }
            else
            {
                user = await _context.UserRegistrations.Where(x => x.Username == loginDto.username && x.Isapproved == true && x.IsDeleted == false).FirstOrDefaultAsync();
            }

            if (user == null)
            {
                return null;
            }

            var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return null;
                }
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

    }
}
