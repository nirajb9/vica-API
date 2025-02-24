using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VICAInsurance.Services.ViewModels;

namespace VICAInsurance.Services.IServices
{
    public interface IPolicyCopyService
    {
        Task<List<PolicyCopyModel>> GetPolicyCopy();
        Task<ResponseResult> SavePolicyCopy(PolicyCopyModel model);
    }
}
