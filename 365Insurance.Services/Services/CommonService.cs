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
    public class CommonService : ICommonService
    {
        private readonly Insure247DbContext _context;

        public CommonService(Insure247DbContext context)
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
            return await _context.PolicyCashbacks.Where(s => s.UserId == searchParam.UserId && s.AgentCompanyId == searchParam.AgentCompanyId).OrderByDescending(s => s.CashbackAmountId).ToListAsync();
        }
        public async Task<CompanySlider> GetCompanySliders(SearchParam searchParam)
        {
            return await _context.CompanySliders.Where(s => s.UserId == searchParam.UserId && s.AgentCompanyId == searchParam.AgentCompanyId).FirstOrDefaultAsync();
        }

    }
}
