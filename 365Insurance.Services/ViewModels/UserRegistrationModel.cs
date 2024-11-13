using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.ViewModels
{
    public class UserRegistrationModel
    {
        public int UserId { get; set; }
        public int AgentCompanyId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? Password { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
    }

    public  class UserDetails
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? Token { get; set; }
        public int? AgentCompanyId { get; set; }
        public string? AgentCompanyName { get; set; }
        public string? LogoUrl { get; set; }
    }
}
