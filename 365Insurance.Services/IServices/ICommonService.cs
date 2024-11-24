using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace VICAInsurance.Services.IServices
{
    public interface ICommonService
    {
        Task<List<VehicleFueltype>> GetVehicleFueltypes();
        Task<List<VehicleType>> GetVehicleType();
        Task<List<VehicleAge>> GetVehicleAge();
        Task<List<StateMa>> GetState();
        Task<List<RtoMa>> GetRTODetails(int stateId);
        Task<List<PolicyPaymentLink>> GetPaymentLink(SearchParam searchParam);
        Task<List<PolicySurveyLink>> GetSurveyLink(SearchParam searchParam);
        Task<List<PolicyType>> GetPolicyType(SearchParam searchParam);
        Task<List<PolicyCashback>> GetPolicyCashback(SearchParam searchParam);
        Task<CompanySlider> GetCompanySliders(SearchParam searchParam);
        Task<List<VehicleInsuranceCompany>> GetVehicleInsuranceCompanies();
        Task<AllMastersModel> GetAllMasters();
        Task<List<ClaimSupportModel>> GetClaimSupport();
        Task<List<MonthlyGridModel>> GetMonthlyGrid();
        Task<List<PolicyCopy>?> GetPolicyCopy(PolicyCopySearch model);
        Task<string> UploadToFtp(IFormFile model);
        Task<string> UploadToFtp(byte[] fileBytes, string fileName, int? userid);

    }
}
