using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.IServices
{
    public interface IRegistrationService
    {
        Task<int> AddUserRegistration(UserRegistrationModel userRegistrationModel);
        Task<List<UserRegistration>> GetUserDetails();
    }
}
