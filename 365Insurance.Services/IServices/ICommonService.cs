using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.IServices
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

    }
}
