using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using VICAInsurance.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace VICAInsurance.Services.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly _247IDbContext _context;

        private readonly ITokenService _tokenService;
        private readonly IRegistrationService _registrationService;
        private readonly Random _random = new Random();

        public RegistrationService(_247IDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddUserRegistration(UserRegistrationModel userRegistrationModel)
        {
            try
            {
                UserRegistration ur = new UserRegistration();
                ur.Email = userRegistrationModel.Email;
                ur.Name = userRegistrationModel.Name;
                ur.Password = userRegistrationModel.Password;
                ur.Isapproved = true;

                _context.UserRegistrations.Add(ur);
                await _context.SaveChangesAsync();
                return ur.UserId;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ResponseResult> UserRegistration(UserRegistrationModel registerDto)
        {
            ResponseResult rr = new ResponseResult();
            try
            {              
                rr.StatusCode = 401;
                if (await UserExists(registerDto.MobileNo, registerDto.AgentCompanyId))
                {
                    rr.StatusCode = 401;
                    rr.Message = "UserName Is Already Taken";                  
                }
                var hmac = new HMACSHA512();
                var userReg = _context.UserRegistrations.OrderBy(x => x.UserId).LastOrDefault();
                int id = userReg != null ? userReg.UserId + 1 : 1;
                if(registerDto.Password == null || registerDto.Password == "")
                {
                    registerDto.Password = RandomPassword();
                }
                
                var user = new UserRegistration
                {                  
                    Name = registerDto.Name.ToLower(),
                    Email = registerDto.Email,
                    MobileNo = registerDto.MobileNo,
                    Username = "V" + id,
                    Isapproved = true,
                    IsDeleted = false,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                    PasswordSalt = hmac.Key,
                    Password = registerDto.Password,
                    AgentCompanyId = registerDto.AgentCompanyId

                };

                _context.UserRegistrations.Add(user);
                await _context.SaveChangesAsync();
                rr.StatusCode = 200;
                rr.Message = "success";
                rr.ModelValue = user;
               
            }
            catch (Exception ex)
            {
                rr.StatusCode = 300;
                rr.Message = "error";
            }

            return rr;
        }
    
        public async Task<List<UserRegistration>> GetUserDetails()
        {
            var userDetails = _context.UserRegistrations.ToListAsync();
            return await userDetails;
        }
        private async Task<bool> UserExists(string mobileno, int agent_company_id)
        {
            return await _context.UserRegistrations.AnyAsync(x => x.MobileNo .ToLower() == mobileno.ToLower() && x.AgentCompanyId == agent_company_id);
        }
        public string RandomPassword()
        {
            var passwordBuilder = new StringBuilder();
            // 4-Letters lower case   
            passwordBuilder.Append(RandomString(6, true));
            return passwordBuilder.ToString();
        }
        // Generates a random string with a given size.
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.

            // char is a single Unicode character
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}
