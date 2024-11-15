using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using VICAInsurance.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.Services
{
    public class CommonService : ICommonService
    {
        private readonly _247IDbContext _context;

        public CommonService(_247IDbContext context)
        {
            _context = context;
        }
        public async Task<List<VehicleFueltype>> GetVehicleFueltypes()
        {
            return await _context.VehicleFueltypes.Where(s => s.IsDeleted == false) .ToListAsync();
        }

        public async Task<List<VehicleType>> GetVehicleType()
        {
            return await _context.VehicleTypes.Where(s => s.IsDeleted == false).ToListAsync();
        }

        public async Task<List<VehicleAge>> GetVehicleAge()
        {
            return await _context.VehicleAges.Where(s => s.IsDeleted == false).ToListAsync();
        }

        public async Task<List<StateMa>> GetState()
        {
            return await _context.StateMas.Where(s => s.IsDeleted == false).ToListAsync();
        }
        public async Task<List<RtoMa>> GetRTODetails(int stateId)
        {
            return await _context.RtoMas.Where(s => s.IsDeleted == false && s.StateId == stateId).ToListAsync();
        }

        public async Task<List<PolicyPaymentLink>> GetPaymentLink(SearchParam searchParam)
        {
            return await _context.PolicyPaymentLinks.Where(s =>s.UserId == searchParam.UserId && s.AgentCompanyId == searchParam.AgentCompanyId && s.IsDeleted == false).OrderByDescending(s=>s.PaymentLinkId).ToListAsync();
        }
        public async Task<List<PolicySurveyLink>> GetSurveyLink(SearchParam searchParam)
        {
            return await _context.PolicySurveyLinks.Where(s => s.UserId == searchParam.UserId && s.AgentCompanyId == searchParam.AgentCompanyId && s.IsDeleted == false).OrderByDescending(s => s.SurveyLinkId).ToListAsync();
        }
        public async Task<List<PolicyType>> GetPolicyType(SearchParam searchParam)
        {
            return await _context.PolicyTypes.Where(s => s.IsDeleted == false).ToListAsync();
        }
        public async Task<List<PolicyCashback>> GetPolicyCashback(SearchParam searchParam)
        {
            return await _context.PolicyCashbacks.Where(s => s.UserId == searchParam.UserId && s.AgentCompanyId == searchParam.AgentCompanyId).OrderByDescending(s => s.PolicyCashbackId).ToListAsync();
        }
        public async Task<CompanySlider> GetCompanySliders(SearchParam searchParam)
        {
            return await _context.CompanySliders.Where(s => s.UserId == searchParam.UserId && s.AgentCompanyId == searchParam.AgentCompanyId).FirstOrDefaultAsync();
        }
        public async Task<List<VehicleInsuranceCompany>> GetVehicleInsuranceCompanies()
        {
            return await _context.VehicleInsuranceCompanies.Where(s => s.IsDeleted == false).ToListAsync();
        }
        public async Task<AllMastersModel> GetAllMasters()
        {
            AllMastersModel allMastersModel = new AllMastersModel();
            allMastersModel.FuelTypeList = await GetVehicleFueltypes();
            allMastersModel.StateList = await GetState();
            allMastersModel.RtoList = await _context.RtoMas.Where(s => s.IsDeleted == false).ToListAsync();
            allMastersModel.VehicleAgeList = await GetVehicleAge();
            allMastersModel.VehicleTypeList = await GetVehicleType();
            allMastersModel.VehicleInsuranceCompanyList = await GetVehicleInsuranceCompanies();
            allMastersModel.VehicleCubicCapicityList= await _context.VehicleCubicCapicities.Where(s => s.IsDeleted == false).ToListAsync();
            allMastersModel.GSTValue = 18;

            return allMastersModel;
        }

        public async Task<List<ClaimSupportModel>> GetClaimSupport()
        {
            List<ClaimSupportModel>? result = null;
            try
            {
                result = await (from cs in _context.ClaimSupports
                          join viv in _context.VehicleInsuranceCompanies on cs.InsuranceCompanyId equals viv.InsuranceCompanyId
                          where cs.IsDeleted == false && viv.IsDeleted == false
                          select new ClaimSupportModel
                          {
                              CompanyName = viv.InsuranceCompanyName,
                              ContactNo = cs.ContactDetails,
                              Id = cs.ClaimSupportId

                          }).ToListAsync();
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<List<MonthlyGridModel>> GetMonthlyGrid()
        {
            List<MonthlyGridModel>? result = null;
            try
            {
                result = await (from mg in _context.MonthlyGridMas
                                join sm in _context.StateMas on mg.StateId equals sm.StateId
                                where mg.IsDeleted == false && sm.IsDeleted == false
                                select new MonthlyGridModel
                                {
                                    FileLink = mg.FileLink,
                                    Month = mg.Month,
                                    StateCode = sm.StateCode,
                                    StateName = sm.StateName,                          
                                    Id = mg.GridId

                                }).ToListAsync();
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<List<PolicyCopy>?> GetPolicyCopy(PolicyCopySearch model)
        {
            List<PolicyCopy>? result = null;
            try
            {
                DateTime? sdate = model.startdate == null ? DateTime.Now : model.startdate;
                DateTime? edate = model.enddate == null ? DateTime.Now : model.enddate;
                result = await _context.PolicyCopies.Where(s => s.UserId == model.userid && s.CreatedDate >= sdate.Value.Date.AddDays(-1) && s.CreatedDate <= edate.Value.Date.AddDays(1) && s.IsDeleted == false).ToListAsync();

            }
            catch (Exception ex)
            {
                return result;
            }

            return result;
        }



    }
}
