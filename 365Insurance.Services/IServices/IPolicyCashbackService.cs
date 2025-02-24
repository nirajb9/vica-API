using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.ViewModels;

namespace VICAInsurance.Services.IServices
{
    public interface IPolicyCashbackService
    {
        string Save(PolicyCashbackRequest model);
        Task<PolicyCashbackModel?> GetPolicyCashback(int userId, int id);
        Task<List<PolicyCashbackRequestModel>> GetPolicyCashbackRequest(int userId);
        Task<List<PolicyCashbackRequestModel>> GetPolicyCashbackRequest();
        Task<ResponseResult> SaveCashback(PolicyCashbackDomainModel model);
        Task<List<PolicyCashbackRequestModel>> GetPolicyCashbackDetails(int id);
    }
}
