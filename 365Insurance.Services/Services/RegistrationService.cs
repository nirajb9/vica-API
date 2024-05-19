using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.IServices;
using _365Insurance.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly Insure247DbContext _context;

        public RegistrationService(Insure247DbContext context)
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
    
        public async Task<List<UserRegistration>> GetUserDetails()
        {
            var userDetails = _context.UserRegistrations.ToListAsync();
            return await userDetails;
        }
    }
}
