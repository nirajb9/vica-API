using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.ViewModels;

namespace VICAInsurance.Services.IServices
{
    public interface IEndorsementPolicyService
    {
        Task<List<EndorsementPolicy>> GetEndorsementPolicy(int userid);
        Task<bool> DeleteEndorsementPolicyAsync(int id);      
        ResponseResult AddEndorsementPolicyAsync(EndorsementPolicy endorsementPolicy);
    }
}
