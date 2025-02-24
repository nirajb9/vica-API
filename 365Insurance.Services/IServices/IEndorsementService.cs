using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.ViewModels;

namespace VICAInsurance.Services.IServices
{
    public interface IEndorsementService
    {
        Task<List<EndorsementModel>> GetEndorsementPolicy();
        Task<EndorsementPolicy?> UpdateEndrosmentPolicy(EndorsementPolicy model);
    }
}
